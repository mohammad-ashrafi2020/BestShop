using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Products;

namespace Shop.Infrastructure.Mapping.Products
{
    public class ProductSpecificationMap : IEntityTypeConfiguration<ProductSpecification>
    {
        public void Configure(EntityTypeBuilder<ProductSpecification> builder)
        {
            builder.ToTable("ProductSpecifications", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.Hint)
                .IsRequired(false);

            builder.Property(b => b.Value)
                .IsRequired();

            builder.HasOne(b => b.Product)
                .WithMany(b => b.ProductSpecifications)
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}