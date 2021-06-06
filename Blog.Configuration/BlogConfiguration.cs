using Blog.Application;
using Blog.Application.Services.PostGroups.DomainServices;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Configuration
{
    public class BlogConfiguration
    {
        public static void Init(IServiceCollection service, string connectionString)
        {
            service.AddScoped<IEnglishTitleUniquenessChecker,EnglishTitleUniquenessChecker>();

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
