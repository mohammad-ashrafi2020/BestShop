using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Products.ProductPictures;

namespace Shop.Infrastructure.EF.Mapping.Products
{
    public class ProductPictureMap:IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures", "dbo");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.ImageName)
                .IsRequired().HasMaxLength(110);

            builder.Property(b => b.ImageAlt)
                .IsRequired().HasMaxLength(400);

            builder.HasOne(b => b.Product)
                .WithMany(b => b.ProductPictures)
                .HasForeignKey(b => b.ProductId);
        }
    }
}