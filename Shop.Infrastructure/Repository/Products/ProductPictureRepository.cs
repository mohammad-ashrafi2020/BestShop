using Common.Domain.Repository;
using Shop.Domain.Products.ProductPictures;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.Products
{
    public class ProductPictureRepository : BaseRepository<long, ProductPicture>, IProductPictureRepository
    {
        public ProductPictureRepository(ShopContext context) : base(context)
        {
        }
    }
}