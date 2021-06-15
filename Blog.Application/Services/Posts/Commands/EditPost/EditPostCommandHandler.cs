using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Common;
using Blog.Application.Services.Posts.Queries.GetById;
using Blog.Application.Utilities;
using Blog.Domain.Entities.BlogPostAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using framework.DateUtil;
using framework.FileUtil;
using framework.SecurityUtil;
using framework.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Posts.Commands.EditPost
{
    public class EditPostCommandHandler : IBaseRequestHandler<EditPostCommand>
    {
        private readonly BlogContext _context;
        private readonly IPostSlugUniquenessChecker _slgChecker;

        public EditPostCommandHandler(BlogContext context, IPostSlugUniquenessChecker slgChecker)
        {
            _context = context;
            _slgChecker = slgChecker;
        }
        public async Task<OperationResult> Handle(EditPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.BlogPosts
                .AsTracking()
                .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
           
            if (post == null)
                return OperationResult.NotFound();

            var imageName = post.ImageName;
            var oldImage = post.ImageName;
            var slug = request.UrlTitle.ToSlug();

            //Save New Image
            if (request.ImageFile != null)
                if (request.ImageFile.IsImage())
                    imageName = await SaveFileInServer.SaveFile(request.ImageFile, BlogDirectories.BlogPost);

            //Edit Post
            post.Edit(request.Tags, request.Title, request.MetaDescription, slug,
                request.Description, imageName, request.ImageAlt, request.TimeRequiredToStudy, request.GroupId, request.SubGroupId
                , request.DateRelease.ToMiladi(), request.IsSpecial, _slgChecker);

            _context.Update(post);
            await _context.SaveChangesAsync(cancellationToken);

            //If User Enter New Image Then Delete Old Image
            if (request.ImageFile != null)
                if (request.ImageFile.IsImage())
                    DeleteFileFromServer.DeleteFile(oldImage, BlogDirectories.BlogPost);

            return OperationResult.Success();
        }



    }
}