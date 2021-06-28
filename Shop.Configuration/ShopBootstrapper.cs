using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.DomainServices;
using Shop.Application.ProductCategories.ProductCategory.Create;
using Shop.Domain.Brands;
using Shop.Domain.Categories;
using Shop.Domain.Categories.CategoryAttributes;
using Shop.Domain.Categories.Rule;
using Shop.Domain.Products;
using Shop.Infrastructure.EF.Context;
using Shop.Infrastructure.EF.Repository.Brands;
using Shop.Infrastructure.EF.Repository.ProductCategories;
using Shop.Infrastructure.EF.Repository.Products;
using Shop.Query.Categories.Category.GetById;

namespace Shop.Configuration
{
    public class ShopBootstrapper
    {
        public static void Init(IServiceCollection service, string connectionString)
        {

            #region Repositories
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<ICategoryAttributeRepository, CategoryAttributeRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IBrandRepository, BrandRepository>();
            #endregion

            #region DomainServices
            service.AddTransient<ICategorySlugUniquenessChecker, CategorySlugUniquenessChecker>();
            #endregion


            //Commands
            service.AddMediatR(typeof(CreateProductCategoryCommand).Assembly);

            //Queries
            service.AddMediatR(typeof(GetProductCategoryById).Assembly);

            service.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}
