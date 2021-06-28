using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Commands.EditGroup
{
    public class EditPostGroupCommandHandler : IBaseRequestHandler<EditPostGroupCommand>
    {
        private readonly BlogContext _context;
        private readonly IEnglishTitleUniquenessChecker _checker;

        public EditPostGroupCommandHandler(BlogContext context, IEnglishTitleUniquenessChecker checker)
        {
            _context = context;
            _checker = checker;
        }


        public async Task<OperationResult> Handle(EditPostGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.BlogPostGroups
                .AsTracking().SingleOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);

            group.Edit(request.EnglishGroupTitle, request.GroupTitle, request.MetaDescription,_checker);
            _context.Update(group);
            await _context.SaveChangesAsync(cancellationToken);

            return OperationResult.Success();
        }

    }
}