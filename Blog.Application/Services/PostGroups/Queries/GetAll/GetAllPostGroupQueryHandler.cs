using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Services.PostGroups.Queries.DTOs;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application;
using framework.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Queries.GetAll
{
    public class GetAllPostGroupQueryHandler : IBaseRequestHandler<GetAllPostGroupQuery, List<BlogPostGroupDto>>
    {
        private readonly BlogContext _context;

        public GetAllPostGroupQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<List<BlogPostGroupDto>> Handle(GetAllPostGroupQuery request, CancellationToken cancellationToken)
        {
            var data = _context.BlogPostGroups.OrderByDescending(d => d.Id)
                .Select(s => new BlogPostGroupDto()
                {
                    EnglishGroupTitle = s.EnglishGroupTitle,
                    GroupTitle = s.GroupTitle,
                    Id = s.Id,
                    Slug = s.EnglishGroupTitle.ToSlug(),
                    ParentId = s.ParentId,
                    MetaDescription = s.MetaDescription,
                    IsActive = !s.IsDelete
                });

            return await data.ToListAsync(cancellationToken);
        }

    }
}