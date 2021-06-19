using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application;
using framework;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Commands.CreateGroup
{
    public class CreatePostGroupCommandHandler : IBaseRequestHandler<CreatePostGroupCommand>
    {
        private BlogContext Context { get; }
        private readonly IEnglishTitleUniquenessChecker _checker;
        public CreatePostGroupCommandHandler(BlogContext context, IEnglishTitleUniquenessChecker checker)
        {
            Context = context;
            _checker = checker;
        }

        public async Task<OperationResult> Handle(CreatePostGroupCommand request, CancellationToken cancellationToken)
        {
            //Add Child
            if (request.ParentId is > 0)
            {
                var parent = await Context.BlogPostGroups.FirstOrDefaultAsync(d => d.Id == request.ParentId,cancellationToken);
                if (parent == null)
                    return OperationResult.NotFound();

                parent.AddChild(request.EnglishGroupTitle, request.GroupTitle, request.MetaDescription,_checker);
                Context.BlogPostGroups.AddRange(parent.Groups);
                return OperationResult.Success();
            }
            //Create New Group
            var group = new BlogPostGroup(request.EnglishGroupTitle, request.GroupTitle, request.MetaDescription, _checker);
            await Context.AddAsync(group, cancellationToken);
            return OperationResult.Success();
        }
    }
}