using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Products;

namespace Shop.Infrastructure.EF.Mapping.Products
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .UseHiLo();

            builder.Property(b => b.EnglishName)
                .IsUnicode(false)
                .HasMaxLength(400);

            builder.Property(b => b.PersianName)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(b => b.ImageName)
                .IsRequired()
                .HasMaxLength(110);

            builder.Property(b => b.BitMapImageName)
                .IsRequired()
                .HasMaxLength(110);

            builder.Property(b => b.ShortDescription)
                .HasMaxLength(500);

            builder.OwnsOne(b => b.MetaValue, nav =>
            {
                nav.Property(b => b.Title)
                    .HasMaxLength(300);
                nav.Property(b => b.Description)
                    .HasMaxLength(400);
                nav.Property(b => b.KeyWords)
                    .HasMaxLength(400);
            });

            builder.OwnsMany(b => b.ProductCategories, navigation =>
            {
                navigation.ToTable("ProductCategories","dbo");
                navigation.HasKey(x => new { x.CategoryId, x.ProductId });
                navigation.Property(b => b.Level);
            });

            builder.HasOne(b => b.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(b => b.BrandId);
        }
    }
}