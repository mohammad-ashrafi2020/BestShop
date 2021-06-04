using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Common;
using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Commands.DeleteGroup
{
    public class DeletePostGroupCommandHandler : IBaseRequestHandler<DeletePostGroupCommand>
    {
        private BlogContext _context;

        public DeletePostGroupCommandHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> Handle(DeletePostGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.BlogPostGroups
                .Include(c => c.MainBlogPosts)
                .Include(c => c.SubBlogPosts)
                .FirstOrDefaultAsync(d => d.Id == request.GroupId && d.IsDelete == false
                    , cancellationToken);
            
            if (group == null)
                return OperationResult.NotFound();

            if (group.MainBlogPosts.Any() || group.SubBlogPosts.Any())
                return OperationResult.Error("گروه مورد نظر دارای پست است و امکان حذف گروه وجود ندارد");

            group.Delete();
            _context.Update(group);
            return OperationResult.Success();
        }

    }
}