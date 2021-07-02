using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.Products;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.Products
{
    public class ProductRepository : BaseRepository<long, Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }


        public async Task SetProductCategories(List<ProductCategory> categories)
        {
            var productId = categories.First().ProductId;
            var currentGroups = Context.ProductCategories.Where(p => p.ProductId == productId);
            Context.ProductCategories.RemoveRange(currentGroups);
            await Context.ProductCategories.AddRangeAsync(categories);
        }
    }
}