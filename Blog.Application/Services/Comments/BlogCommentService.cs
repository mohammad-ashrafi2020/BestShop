using Blog.Infrastructure.Context;
using framework.Services;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Comments
{
    public class BlogCommentService : BaseService, IBlogCommentService
    {
        public BlogCommentService(BlogContext context) : base(context)
        {
        }
    }
}