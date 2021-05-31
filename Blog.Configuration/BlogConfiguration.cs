using Blog.Application;
using Blog.Application.Services.Comments;
using Blog.Application.Services.Groups;
using Blog.Application.Services.Post;
using Blog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Configuration
{
    public class BlogConfiguration
    {
        public static void Init(IServiceCollection service, string connectionString)
        {
            service.AddAutoMapper(typeof(AutoMapperProfile));

            service.AddScoped<IBlogCommentService, BlogCommentService>();
            service.AddScoped<IBlogGroupService, BlogGroupService>();
            service.AddScoped<IBlogPostService, BlogPostService>();
            service.AddDbContext<BlogContext>(option =>
            {
                option.UseSqlServer(connectionString,
                    builder => builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });
        }
    }
}
