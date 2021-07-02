using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Products.ProductSpecifications;

namespace Shop.Infrastructure.EF.Mapping.Products
{
    public class ProductSpecificationMap : IEntityTypeConfiguration<ProductSpecification>
    {
        public void Configure(EntityTypeBuilder<ProductSpecification> builder)
        {
            builder.ToTable("ProductSpecifications", "dbo");
            builder.HasKey(b => new { b.Id, b.CategoryAttributeId });

            builder.Property(b => b.Value)
                .IsRequired().HasMaxLength(600);


            builder.HasOne(b => b.Product)
                .WithMany(b => b.ProductSpecifications)
                .HasForeignKey(b => b.ProductId);
        }
    }
}