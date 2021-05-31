using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Products.Category;

namespace Shop.Infrastructure.Mapping.Products.Category
{
    public class ProductCategorySpecificationItemMap : IEntityTypeConfiguration<ProductCategorySpecificationItem>
    {
        public void Configure(EntityTypeBuilder<ProductCategorySpecificationItem> builder)
        {
            builder.ToTable("ProductCategorySpecificationItems", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(b => b.Hint)
                .IsRequired(false);

            builder.HasOne(b => b.CategorySpecification)
                .WithMany(b => b.Items)
                .HasForeignKey(b => b.CategorySpecificationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}