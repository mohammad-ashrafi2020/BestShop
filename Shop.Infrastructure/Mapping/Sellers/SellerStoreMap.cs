using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Sellers;

namespace Shop.Infrastructure.Mapping.Sellers
{
    public class SellerStoreMap : IEntityTypeConfiguration<SellerStore>
    {
        public void Configure(EntityTypeBuilder<SellerStore> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}