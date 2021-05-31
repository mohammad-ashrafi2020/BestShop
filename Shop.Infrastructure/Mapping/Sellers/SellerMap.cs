using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Sellers;

namespace Shop.Infrastructure.Mapping.Sellers
{
    public class SellerMap : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}