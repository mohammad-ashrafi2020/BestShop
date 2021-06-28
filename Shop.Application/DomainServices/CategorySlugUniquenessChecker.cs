using System.Linq;
using Common.Core.Utilities;
using Shop.Domain.Categories.Rule;
using Shop.Infrastructure.EF.Context;

namespace Shop.Application.DomainServices
{
    public class CategorySlugUniquenessChecker : ICategorySlugUniquenessChecker
    {
        private readonly ShopContext _db;

        public CategorySlugUniquenessChecker(ShopContext db)
        {
            _db = db;
        }
        public bool IsUniq(string slug)
        {
            return _db.Categories.Any(p => p.Slug == slug.ToSlug());
        }
    }
}