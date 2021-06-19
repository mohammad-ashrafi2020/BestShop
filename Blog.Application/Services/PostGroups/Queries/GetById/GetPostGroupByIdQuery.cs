using Blog.Application.Services.PostGroups.Queries.DTOs;
using Common.Application;

namespace Blog.Application.Services.PostGroups.Queries.GetById
{
    public class GetPostGroupByIdQuery : IBaseRequest<BlogPostGroupDto>
    {
        public GetPostGroupByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}