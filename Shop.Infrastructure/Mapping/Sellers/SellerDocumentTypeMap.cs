using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Sellers;

namespace Shop.Infrastructure.Mapping.Sellers
{
    public class SellerDocumentTypeMap : IEntityTypeConfiguration<SellerDocumentType>
    {
        public void Configure(EntityTypeBuilder<SellerDocumentType> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}