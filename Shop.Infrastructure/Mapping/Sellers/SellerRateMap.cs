using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Sellers;

namespace Shop.Infrastructure.Mapping.Sellers
{
    public class SellerRateMap : IEntityTypeConfiguration<SellerRate>
    {
        public void Configure(EntityTypeBuilder<SellerRate> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}