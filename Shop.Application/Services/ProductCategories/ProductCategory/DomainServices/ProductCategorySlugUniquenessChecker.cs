using System.Linq;
using Common.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductCategories.ProductCategory.Rule;
using Shop.Infrastructure.EF.Context;

namespace Shop.Application.Services.ProductCategories.ProductCategory.DomainServices
{
    public class ProductCategorySlugUniquenessChecker : IProductCategorySlugUniquenessChecker
    {
        private readonly ShopContext _db;

        public ProductCategorySlugUniquenessChecker(ShopContext db)
        {
            _db = db;
        }
        public bool IsUniq(string slug)
        {
            return _db.ProductCategories.Any(p => p.Slug == slug.ToSlug());
        }
    }
}