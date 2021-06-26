using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Mapper;
using Blog.Application.Services.Posts.Queries.DTOs;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Posts.Queries.GetById
{
    public class GetPostByIdQueryHandler : IBaseRequestHandler<GetPostByIdQuery, BlogPostDto>
    {
        private readonly BlogContext _context;

        public GetPostByIdQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<BlogPostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.BlogPosts
                .Include(c => c.Group)
                .Include(c => c.SubGroup)
                .SingleOrDefaultAsync(s => s.Id == request.PostId, cancellationToken: cancellationToken);
           

            return BlogPostMapper.MapBlogPostToDto(value);
        }

    }
}