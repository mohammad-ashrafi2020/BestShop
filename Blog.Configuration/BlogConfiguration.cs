using Blog.Application;
using Blog.Infrastructure.Persistent.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Configuration
{
    public class BlogConfiguration
    {
        public static void Init(IServiceCollection service, string connectionString)
        {
            service.AddAutoMapper(typeof(AutoMapperProfile));

           
            service.AddDbContext<BlogContext>(option =>
            {
                option.UseSqlServer(connectionString,
                    builder =>
                    {
                        builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
            });
        }
    }
}
