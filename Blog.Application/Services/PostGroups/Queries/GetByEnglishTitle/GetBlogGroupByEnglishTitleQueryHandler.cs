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
        public GetBlogGroupByEnglishTitleQueryHandler(BlogContext context)
        {
            _Context = context;
        }

        public BlogContext _Context { get; }

        public async Task<BlogPostGroupDto> Handle(GetBlogGroupByEnglishTitleQuery request, CancellationToken cancellationToken)
        {
            return await _Context.BlogPostGroups.Select(s => new BlogPostGroupDto()
            {
                EnglishGroupTitle = s.EnglishGroupTitle,
                GroupTitle = s.GroupTitle,
                Id = s.Id,
                ParentId = s.ParentId,
                Slug = s.EnglishGroupTitle.ToSlug()
            }).SingleOrDefaultAsync(u => u.EnglishGroupTitle == request.EnglishTitle
                , cancellationToken: cancellationToken);
        }

    }
}