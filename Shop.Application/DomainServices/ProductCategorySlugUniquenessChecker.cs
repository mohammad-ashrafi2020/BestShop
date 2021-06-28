using System.Linq;
using Common.Core.Utilities;
using Shop.Domain.ProductCategories.ProductCategory.Rule;
using Shop.Infrastructure.EF.Context;

namespace Shop.Application.DomainServices
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