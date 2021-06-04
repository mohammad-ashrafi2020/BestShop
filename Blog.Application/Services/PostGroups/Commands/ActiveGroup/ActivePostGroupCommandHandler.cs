using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Common;
using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Commands.ActiveGroup
{
    public class ActivePostGroupCommandHandler:IBaseRequestHandler<ActivePostGroupCommand>
    {
        private BlogContext _db;

        public ActivePostGroupCommandHandler(BlogContext db)
        {
            _db = db;
        }
        public async Task<OperationResult> Handle(ActivePostGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _db.BlogPostGroups
                .AsTracking()
                .SingleOrDefaultAsync(d => d.Id == request.GroupId && d.IsDelete, cancellationToken);

            if (group == null)
                return OperationResult.NotFound();

            group.Recovery();
            _db.Update(group);
            return OperationResult.Success();
        }
    }
}