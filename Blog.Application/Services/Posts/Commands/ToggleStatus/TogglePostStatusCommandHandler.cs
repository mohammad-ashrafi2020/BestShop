using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;

namespace Blog.Application.Services.Posts.Commands.ToggleStatus
{
    class TogglePostStatusCommandHandler : IBaseRequestHandler<TogglePostStatusCommand>
    {
        private readonly BlogContext _db;

        public TogglePostStatusCommandHandler(BlogContext db)
        {
            _db = db;
        }

        public TogglePostStatusCommandHandler()
        {

        }
        public async Task<OperationResult> Handle(TogglePostStatusCommand request, CancellationToken cancellationToken)
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
