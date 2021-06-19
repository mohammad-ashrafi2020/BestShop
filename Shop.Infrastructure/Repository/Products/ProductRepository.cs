using Shop.Domain.Products;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.Products
{
    public class ProductRepository : BaseRepository<long, Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}