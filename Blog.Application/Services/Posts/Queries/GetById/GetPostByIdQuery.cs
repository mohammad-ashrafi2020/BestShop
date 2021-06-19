using Blog.Application.Services.Posts.Queries.DTOs;
using Common.Application;

namespace Blog.Application.Services.Posts.Queries.GetById
{
    public class GetPostByIdQuery:IBaseRequest<BlogPostDto>
    {
        public GetPostByIdQuery(long postId)
        {
            PostId = postId;
        }

        public long PostId { get; private set; }
    }
}