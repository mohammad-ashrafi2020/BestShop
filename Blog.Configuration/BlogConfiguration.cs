using Blog.Application;
using Blog.Application.Common.Validation;
using Blog.Application.Services.PostGroups.Commands.TogglePostGroupStatus;
using Blog.Application.Services.PostGroups.DomainServices;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Configuration
{
    public class BlogConfiguration
    {
        public static void Init(IServiceCollection service, string connectionString)
        {
            service.AddScoped<IEnglishTitleUniquenessChecker,EnglishTitleUniquenessChecker>();
            service.AddMediatR(typeof(TogglePostGroupStatusCommand).Assembly);
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));

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
