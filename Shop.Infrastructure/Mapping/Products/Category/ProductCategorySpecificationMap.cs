using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Products.Category;

namespace Shop.Infrastructure.Mapping.Products.Category
{
    public class ProductCategorySpecificationMap : IEntityTypeConfiguration<ProductCategorySpecification>
    {
        public void Configure(EntityTypeBuilder<ProductCategorySpecification> builder)
        {
            builder.ToTable("ProductCategorySpecifications", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(400);

            builder.Property(b => b.Hint)
                .IsRequired(false);

            builder.HasOne(b => b.ProductCategory)
                .WithMany(b => b.Specifications)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}