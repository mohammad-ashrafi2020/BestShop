using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
        public IMapper _Mapper { get; }
        public CreateGroupCommandHandler(BlogContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<OperationResult> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            if (await _Context.BlogPostGroups.AnyAsync(c => c.EnglishGroupTitle == request.EnglishGroupTitle, cancellationToken))
                return OperationResult.Error("عنوان انگلیسی تکراری است");

            var group = new BlogPostGroup(request.EnglishGroupTitle, request.GroupTitle, request.MetaDescription, request.ParentId);
            await _Context.AddAsync(group, cancellationToken);
            return OperationResult.Success();
        }
    }
}