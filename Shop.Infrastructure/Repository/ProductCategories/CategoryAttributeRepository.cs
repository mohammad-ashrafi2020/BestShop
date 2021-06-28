using Shop.Domain.Categories.CategoryAttributes;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.ProductCategories
{
    public class CategoryAttributeRepository : BaseRepository<long, CategoryAttribute>, ICategoryAttributeRepository
    {
        public CategoryAttributeRepository(ShopContext context) : base(context)
        {
        }
    }
}