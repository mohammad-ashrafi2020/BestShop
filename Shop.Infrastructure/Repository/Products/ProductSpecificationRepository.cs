using Shop.Domain.Products.ProductSpecifications;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.Products
{
    public class ProductSpecificationRepository:BaseRepository<long,ProductSpecification>,IProductSpecificationRepository
    {
        public ProductSpecificationRepository(ShopContext context) : base(context)
        {
        }
    }
}