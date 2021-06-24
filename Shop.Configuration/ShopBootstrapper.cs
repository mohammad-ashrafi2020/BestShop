using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.ProductCategories.ProductCategory.Commands.Create;
using Shop.Application.ProductCategories.ProductCategory.DomainServices;
using Shop.Domain.ProductCategories.ProductCategory;
using Shop.Domain.ProductCategories.ProductCategory.Rule;
using Shop.Domain.Products;
using Shop.Infrastructure.EF.Context;
using Shop.Infrastructure.EF.Repository.ProductCategories;
using Shop.Infrastructure.EF.Repository.Products;
using Shop.Query.Services.ProductCategories.ProductCategory.GetById;

namespace Shop.Configuration
{
    public class ShopBootstrapper
    {
        public static void Init(IServiceCollection service, string connectionString)
        {

            #region Repositories
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            #endregion

            #region DomainServices
            service.AddTransient<IProductCategorySlugUniquenessChecker, ProductCategorySlugUniquenessChecker>();
            #endregion


            //Commands
            service.AddMediatR(typeof(CreateProductCategoryCommand).Assembly);

            //Queries
            service.AddMediatR(typeof(GetProductCategoryById).Assembly);

            service.AddDbContext<ShopContext>(option =>
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
