using Blog.Application.Services.Posts.Queries.DTOs;
using Common.Application;
using framework.Enums;

namespace Blog.Application.Services.Posts.Queries.GetAllByFilter
{
    public class GetAllPostByFilterQuery:IBaseRequest<BlogPostFilterDto>
    {
        public GetAllPostByFilterQuery(SearchOn type, string groupName, string search, int take, int pageId)
        {
            SearchOn = type;
            GroupName = groupName;
            Search = search;
            Take = take;
            PageId = pageId;
        }

        public string Search { get; private set; }
        public string GroupName { get; private set; }
        public SearchOn SearchOn { get; private set; }
        public int Take { get; private set; }
        public int PageId { get; private set; }
    }
}