using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Sellers;

namespace Shop.Infrastructure.Mapping.Sellers
{
    public class SellerSendTypeMap : IEntityTypeConfiguration<SellerSendType>
    {
        public void Configure(EntityTypeBuilder<SellerSendType> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}