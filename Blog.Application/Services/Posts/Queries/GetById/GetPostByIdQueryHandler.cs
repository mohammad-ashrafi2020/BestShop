using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Common;
using Blog.Application.Mapper;
using Blog.Application.Services.Posts.Queries.DTOs;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Infrastructure.Persistent.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Posts.Queries.GetById
{
    public class GetPostByIdQueryHandler : IBaseRequestHandler<GetPostByIdQuery, BlogPostDto>
    {
        public GetPostByIdQueryHandler(BlogContext context)
        {
            _Context = context;
        }

        public BlogContext _Context { get; }

        public async Task<BlogPostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            return await _Context.BlogPosts
                .Include(c => c.Group)
                .Include(c => c.SubGroup)
                .Select(s =>
                    BlogPostMapper.MapBlogPostToDto(s))
                .SingleOrDefaultAsync(s => s.Id == request.PostId, cancellationToken: cancellationToken);
        }

    }
}