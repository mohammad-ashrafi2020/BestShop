using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Mapper;
using Blog.Application.Services.Posts.Queries.DTOs;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application;
using Common.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Posts.Queries.GetAllByFilter
{
    public class GetAllPostByFilterQueryHandler : IBaseRequestHandler<GetAllPostByFilterQuery, BlogPostFilterDto>
    {
        private readonly BlogContext _context;

        public GetAllPostByFilterQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<BlogPostFilterDto> Handle(GetAllPostByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _context.BlogPosts
                .Include(c=>c.Group)
                .Include(c=>c.SubGroup)
                .Select(s => BlogPostMapper.MapBlogPostToDto(s));

            if (request.SearchOn == SearchOn.Active)
                result = result.Where(r => r.IsActive);
            else if (request.SearchOn == SearchOn.Deleted)
                result = result.Where(r => !r.IsActive);

            if (!string.IsNullOrWhiteSpace(request.GroupName))
                result = result.Where(g =>
                                              g.Group.EnglishGroupTitle.Contains(request.GroupName)
                                           || g.Group.GroupTitle.Contains(request.GroupName)
                                           || g.SubGroup.EnglishGroupTitle.Contains(request.GroupName)
                                           || g.SubGroup.GroupTitle.Contains(request.GroupName));

            if (!string.IsNullOrWhiteSpace(request.Search))
                result = result.Where(r => r.Title.Contains(request.Search) || r.Tags.Contains(request.Search) || r.Slug.Contains(request.Search));

            var skip = (request.PageId - 1) * request.Take;
            var model = new BlogPostFilterDto()
            {
                SearchOn = request.SearchOn,
                GroupName = request.GroupName,
                Search = request.Search,
                Posts = await result.Skip(skip).Take(request.Take).ToListAsync(cancellationToken: cancellationToken)
            };
            model.GeneratePaging(result, request.Take, request.PageId);
            return model;
        }

    }
}