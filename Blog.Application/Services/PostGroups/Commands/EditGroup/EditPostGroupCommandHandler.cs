using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application;
using framework;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Commands.EditGroup
{
    public class EditPostGroupCommandHandler : IBaseRequestHandler<EditPostGroupCommand>
    {
        private BlogContext Context { get; }
        private readonly IEnglishTitleUniquenessChecker _checker;

        public EditPostGroupCommandHandler(BlogContext context, IEnglishTitleUniquenessChecker checker)
        {
            Context = context;
            _checker = checker;
        }


        public async Task<OperationResult> Handle(EditPostGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await Context.BlogPostGroups
                .AsTracking().SingleOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);

            group.Edit(request.EnglishGroupTitle, request.GroupTitle, request.MetaDescription,_checker);
            Context.Update(group);

            return OperationResult.Success();
        }

    }
}