using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Services.PostGroups.Queries.DTOs;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application;
using framework.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Queries.GetById
{
    public class GetPostGroupByIdQueryHandler : IBaseRequestHandler<GetPostGroupByIdQuery, BlogPostGroupDto>
    {
        private readonly BlogContext _context;

        public GetPostGroupByIdQueryHandler(BlogContext context)
        {
            _context = context;
        }


        public async Task<BlogPostGroupDto> Handle(GetPostGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var group = await _context.BlogPostGroups
                .Where(g => !g.IsDelete)
                .Select(s => new BlogPostGroupDto()
                {
                    EnglishGroupTitle = s.EnglishGroupTitle,
                    GroupTitle = s.GroupTitle,
                    Id = s.Id,
                    ParentId = s.ParentId,
                    Slug = s.EnglishGroupTitle.ToSlug(),
                    MetaDescription = s.MetaDescription
                }).SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

            return group;
        }

    }
}