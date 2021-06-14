using Blog.Application.Common;
using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Services.Posts.Commands.ToggleStatus
{
    class ToggleBlogPostCommandHandler : IBaseRequestHandler<ToggleBlogPostCommand>
    {
        private readonly BlogContext _db;

        public ToggleBlogPostCommandHandler(BlogContext db)
        {
            _db = db;
        }

        public ToggleBlogPostCommandHandler()
        {

        }
        public async Task<OperationResult> Handle(ToggleBlogPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _db.BlogPosts.SingleOrDefaultAsync(p => p.Id == request.PostId, cancellationToken: cancellationToken);
            if (post == null)
                return OperationResult.NotFound();

            if (!post.IsDelete)
                post.Delete();
            else
                post.Recovery();

            _db.Update(post);
            return OperationResult.Success();
        }
    }
}
