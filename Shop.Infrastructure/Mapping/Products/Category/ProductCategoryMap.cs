using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Products.Category;

namespace Shop.Infrastructure.Mapping.Products.Category
{
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.ImageName)
                .IsRequired()
                .HasDefaultValue("Default.jpg")
                .HasMaxLength(150);

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.EnglishTitle)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(400);

            builder.Property(b => b.MetaDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(400);
        }
    }
}