using Blog.Application;
using Blog.Application.Services.PostGroups.Commands.TogglePostGroupStatus;
using Blog.Application.Services.PostGroups.DomainServices;
using Blog.Application.Services.Posts.DomainServices;
using Blog.Domain.Entities.BlogPostAggregate.Rules;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Configuration
{
    public class BlogBootstrapper
    {
        public static void Init(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IEnglishTitleUniquenessChecker,EnglishTitleUniquenessChecker>();
            service.AddMediatR(typeof(TogglePostGroupStatusCommand).Assembly);
            service.AddTransient<IPostSlugUniquenessChecker,PostSlugUniquenessChecker>();

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
