using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Common;
using Blog.Application.Utilities;
using Blog.Domain.Entities.BlogPostAggregate;
using Blog.Domain.Entities.BlogPostAggregate.Rules;
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
        private readonly BlogContext _context;
        private readonly IPostSlugUniquenessChecker _slgChecker;
        public CreatePostCommandHandler(BlogContext context, IPostSlugUniquenessChecker slgChecker)
        {
            _context = context;
            _slgChecker = slgChecker;
        }

        public async Task<OperationResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if(request.ImageFile==null)
                return OperationResult.Error("عکس را وارد کنید");

            if (!request.ImageFile.IsImage())
                return OperationResult.Error("عکس نامعتبر است");

            if (request.Slug.IsUniCode())
                return OperationResult.Error("عنوان انگلیسی فقط قادر به ذخیره متن انگلیسی می باشد");


            var imageName = await SaveFileInServer.SaveFile(request.ImageFile,
                BlogDirectories.BlogPost);

            await _context.BlogPosts.AddAsync(
                new BlogPost(
                    request.AuthorId,
                    request.Title,
                    request.MetaDescription,
                    request.Slug,
                    request.Description.SanitizeText(),
                    imageName,
                    request.ImageAlt,
                    request.Tags,
                    GenerateShortLink(4),
                    request.TimeRequiredToStudy,
                    request.GroupId,
                    request.SubGroupId,
                    request.DateRelease.ToMiladi(),
                    request.IsSpecial, _slgChecker), cancellationToken);

            return OperationResult.Success();
        }

        private string GenerateShortLink(int length)
        {
            var key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
            while (_context.BlogPosts.Any(p => p.ShortLink == key))
            {
                key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
            }
            return key;
        }
    }
}