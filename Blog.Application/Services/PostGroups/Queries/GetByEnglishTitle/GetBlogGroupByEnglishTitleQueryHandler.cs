using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Common;
using Blog.Application.Services.PostGroups.Queries.DTOs;
using Blog.Infrastructure.Persistent.EF.Context;
using framework.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostGroups.Queries.GetByEnglishTitle
{
    public class GetBlogGroupByEnglishTitleQueryHandler:IBaseRequestHandler<GetBlogGroupByEnglishTitleQuery,BlogPostGroupDto>
    {
        private readonly BlogContext _context;

        public GetBlogGroupByEnglishTitleQueryHandler(BlogContext context)
        {
            _context = context;
        }


        public async Task<BlogPostGroupDto> Handle(GetBlogGroupByEnglishTitleQuery request, CancellationToken cancellationToken)
        {
            return await _context.BlogPostGroups
                .Where(g=>!g.IsDelete)
                .Select(s => new BlogPostGroupDto()
            {
                EnglishGroupTitle = s.EnglishGroupTitle,
                GroupTitle = s.GroupTitle,
                Id = s.Id,
                ParentId = s.ParentId,
                Slug = s.EnglishGroupTitle.ToSlug(),
                MetaDescription = s.MetaDescription
            }).SingleOrDefaultAsync(u => u.EnglishGroupTitle == request.EnglishTitle
                , cancellationToken: cancellationToken);
        }

    }
}