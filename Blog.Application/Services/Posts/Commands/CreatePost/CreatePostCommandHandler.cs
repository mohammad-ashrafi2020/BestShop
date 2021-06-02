using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application.Common;
using Blog.Application.Utilities;
using Blog.Domain.Entities.BlogPostAggregate;
using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using framework.DateUtil;
using framework.FileUtil;
using framework.SecurityUtil;
using framework.Utilities;

namespace Blog.Application.Services.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IBaseRequestHandler<CreatePostCommand>
    {
        public BlogContext _Context { get; }
        public IMapper _Mapper { get; }
        public CreatePostCommandHandler(BlogContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<OperationResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if(_Context.BlogPosts.Any(p=>p.UrlTitle==request.UrlTitle))
                return OperationResult.Error("عنوان انگلیسی تکراری است");

            if(!request.ImageFile.IsImage())
                return OperationResult.Error("عکس نامعتبر است");

            if(request.UrlTitle.IsUniCode())
                return OperationResult.Error("عنوان انگلیسی فقط قادر به ذخیره متن انگلیسی می باشد");


            var imageName = await SaveFileInServer.SaveFile(request.ImageFile,
                BlogDirectories.BlogPost(request.UrlTitle.ToSlug()));

            await _Context.BlogPosts.AddAsync(
                new BlogPost(
                    request.AuthorId,
                    request.Title,
                    request.MetaDescription,
                    request.UrlTitle,
                    request.Description.SanitizeText(),
                    imageName,
                    request.ImageAlt,
                    request.Tags,
                    GenerateShortLink(4),
                    request.TimeRequiredToStudy,
                    request.GroupId,
                    request.SubGroupId,
                    request.DateRelease.ToMiladi(),
                    request.IsSpecial), cancellationToken);

            return OperationResult.Success();
        }

        private string GenerateShortLink(int length)
        {
            var key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
            while (_Context.BlogPosts.Any(p => p.ShortLink == key))
            {
                key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
            }
            return key;
        }
    }
}