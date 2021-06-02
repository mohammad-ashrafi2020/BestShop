using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Common;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Commands.EditGroup
{
    public class EditPostGroupCommandHandler : IBaseRequestHandler<EditPostGroupCommand>
    {
        public BlogContext _Context { get; }

        public EditPostGroupCommandHandler(BlogContext context)
        {
            _Context = context;
        }


        public async Task<OperationResult> Handle(EditPostGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _Context.BlogPostGroups.SingleOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);


            if (group.EnglishGroupTitle != request.EnglishGroupTitle)
                if (await _Context.BlogPostGroups.AnyAsync(c => c.EnglishGroupTitle == request.EnglishGroupTitle, cancellationToken))
                    return OperationResult.Error("عنوان انگلیسی تکراری است");

            group.Edit(request.EnglishGroupTitle, request.GroupTitle, request.MetaDescription, request.ParentId);
            _Context.Update(group);

            return OperationResult.Success();
        }

    }
}