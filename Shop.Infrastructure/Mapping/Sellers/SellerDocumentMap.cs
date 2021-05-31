using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Sellers;

namespace Shop.Infrastructure.Mapping.Sellers
{
    public class SellerDocumentMap : IEntityTypeConfiguration<SellerDocument>
    {
        public void Configure(EntityTypeBuilder<SellerDocument> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}