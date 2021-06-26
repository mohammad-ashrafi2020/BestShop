using System.Collections.Generic;
using Blog.Application.Services.PostGroups.Queries.DTOs;
using Common.Application;

namespace Blog.Application.Services.PostGroups.Queries.GetChildGroups
{
    public class GetBlogChildGroupsQuery:IBaseRequest<List<BlogPostGroupDto>>
    {
        public GetBlogChildGroupsQuery(long parentId)
        {
            ParentId = parentId;
        }

        public long ParentId { get; private set; }
    }
}