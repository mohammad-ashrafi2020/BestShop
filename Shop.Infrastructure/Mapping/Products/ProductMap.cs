using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Products;

namespace Shop.Infrastructure.Mapping.Products
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.ShortLink).IsUnique();
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.ImageName)
                .IsRequired()
                .HasDefaultValue("Default.jpg")
                .HasMaxLength(120);

            builder.Property(b => b.BannerImage)
                .HasDefaultValue("Default.jpg")
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.EnglishTitle)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.ImageAlt)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(b => b.MetaDescription)
                .IsRequired()
                .HasMaxLength(400);

            builder.Property(b => b.ShortLink)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(10);

            builder.Property(b => b.Tags)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(b => b.Warning)
                .IsRequired(false);

            builder.HasOne(b => b.Category)
                .WithMany(b => b.Products)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.SubCategory)
                .WithMany(b => b.SubProducts)
                .HasForeignKey(b => b.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.SecondSubCategory)
                .WithMany(b => b.SecondSubProducts)
                .HasForeignKey(b => b.SecondSubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}