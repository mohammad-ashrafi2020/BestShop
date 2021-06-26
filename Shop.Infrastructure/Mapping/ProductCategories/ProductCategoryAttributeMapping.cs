using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductCategories.ProductCategoryAttributes;

namespace Shop.Infrastructure.EF.Mapping.ProductCategories
{
    public class ProductCategoryAttributeMapping : IEntityTypeConfiguration<ProductCategoryAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryAttribute> builder)
        {
            builder.ToTable("ProductCategoryAttributes", "dbo");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Key)
                .IsRequired().HasMaxLength(300);

            builder.HasOne(b => b.ProductCategory)
                .WithMany(b => b.Attributes)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}