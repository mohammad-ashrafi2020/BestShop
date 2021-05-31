using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Products;

namespace Shop.Infrastructure.Mapping.Products
{
    public class ProductGalleryMap : IEntityTypeConfiguration<ProductGallery>
    {
        public void Configure(EntityTypeBuilder<ProductGallery> builder)
        {
            builder.ToTable("ProductGalleries", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.ImageName)
                .IsRequired()
                .HasMaxLength(120);

            builder.HasOne(b => b.Product)
                .WithMany(b => b.ProductGalleries)
                .HasForeignKey(b=>b.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}