using System.Threading;
using System.Threading.Tasks;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application;
using framework;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Commands.TogglePostGroupStatus
{
    public class TogglePostGroupStatusCommandHandler : IBaseRequestHandler<TogglePostGroupStatusCommand>
    {
        private BlogContext _db;

        public TogglePostGroupStatusCommandHandler(BlogContext db)
        {
            _db = db;
        }
        public async Task<OperationResult> Handle(TogglePostGroupStatusCommand request, CancellationToken cancellationToken)
        {
            var group = await _db.BlogPostGroups
                .AsTracking()
                .FirstOrDefaultAsync(d => d.Id == request.GroupId, cancellationToken);

            if (group == null)
                return OperationResult.NotFound();

            if (group.IsDelete)
                group.Recovery();
            else
                group.Delete();

            _db.Update(group);
            return OperationResult.Success();
        }
    }
}