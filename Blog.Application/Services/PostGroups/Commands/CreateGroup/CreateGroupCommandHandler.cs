using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Common;
using Blog.Domain.Entities;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IBaseRequestHandler<CreateGroupCommand>
    {
        public BlogContext _Context { get; }
        public CreateGroupCommandHandler(BlogContext context)
        {
            _Context = context;
        }

        public async Task<OperationResult> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            if (await _Context.BlogPostGroups.AnyAsync(c => c.EnglishGroupTitle == request.EnglishGroupTitle, cancellationToken))
                return OperationResult.Error("عنوان انگلیسی تکراری است");

            //Add Child
            if (request.ParentId is > 0)
            {
                var parent = await _Context.BlogPostGroups.SingleOrDefaultAsync(d => d.Id == request.ParentId, cancellationToken: cancellationToken);
                if (parent == null)
                    return OperationResult.NotFound();

                parent.AddChild(request.EnglishGroupTitle, request.GroupTitle, request.MetaDescription);
                _Context.BlogPostGroups.AddRange(parent.Groups);
                return OperationResult.Success();
            }
            //Create New Group
            var group = new BlogPostGroup(request.EnglishGroupTitle, request.GroupTitle, request.MetaDescription);
            await _Context.AddAsync(group, cancellationToken);
            return OperationResult.Success();
        }
    }
}