using Shop.Domain.Brands;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.Brands
{
    public class BrandRepository:BaseRepository<int,Brand>,IBrandRepository
    {
        public BrandRepository(ShopContext context) : base(context)
        {
        }
    }
}