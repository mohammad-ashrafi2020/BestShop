using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Common;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
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
            var group = await Context.BlogPostGroups.SingleOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);


            if (group.EnglishGroupTitle != request.EnglishGroupTitle)
                if (await Context.BlogPostGroups.AnyAsync(c => c.EnglishGroupTitle == request.EnglishGroupTitle, cancellationToken))
                    return OperationResult.Error("عنوان انگلیسی تکراری است");

            group.Edit(request.EnglishGroupTitle, request.GroupTitle, request.MetaDescription,_checker);
            Context.Update(group);

            return OperationResult.Success();
        }

    }
}