using System.Collections.Generic;
using Blog.Application.Common;
using Blog.Application.Services.PostGroups.Queries.DTOs;

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