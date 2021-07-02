using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Categories.Create;
using Shop.Application.DomainServices;
using Shop.Domain.Brands;
using Shop.Domain.Categories;
using Shop.Domain.Categories.CategoryAttributes;
using Shop.Domain.Categories.Rule;
using Shop.Domain.Products;
using Shop.Domain.Products.ProductPictures;
using Shop.Domain.Products.ProductSpecifications;
using Shop.Infrastructure.EF.Context;
using Shop.Infrastructure.EF.Repository.Brands;
using Shop.Infrastructure.EF.Repository.Categories;
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
            service.AddScoped<IProductPictureRepository, ProductPictureRepository>();
            service.AddScoped<IProductSpecificationRepository, ProductSpecificationRepository>();
            service.AddScoped<ICategoryAttributeRepository, CategoryAttributeRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IBrandRepository, BrandRepository>();
            #endregion

            #region DomainServices
            service.AddTransient<ICategorySlugUniquenessChecker, CategorySlugUniquenessChecker>();
            #endregion


            //Commands
            service.AddMediatR(typeof(CreateCategoryCommand).Assembly);

            //Queries
            service.AddMediatR(typeof(GetProductCategoryById).Assembly);

            service.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}
