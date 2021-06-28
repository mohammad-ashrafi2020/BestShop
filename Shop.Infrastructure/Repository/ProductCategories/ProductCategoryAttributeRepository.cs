using Shop.Domain.ProductCategories.ProductCategoryAttributes;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.ProductCategories
{
    public class ProductCategoryAttributeRepository : BaseRepository<long, ProductCategoryAttribute>, IProductCategoryAttributeRepository
    {
        public ProductCategoryAttributeRepository(ShopContext context) : base(context)
        {
        }
    }
}