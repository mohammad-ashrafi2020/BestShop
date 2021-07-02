using Shop.Domain.Categories;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.Categories
{
    public class CategoryRepository : BaseRepository<int, Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }
    }
}