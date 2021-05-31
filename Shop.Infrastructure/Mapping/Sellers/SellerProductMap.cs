using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Sellers;

namespace Shop.Infrastructure.Mapping.Sellers
{
    public class SellerProductMap : IEntityTypeConfiguration<SellerProduct>
    {
        public void Configure(EntityTypeBuilder<SellerProduct> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}