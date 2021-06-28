using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Brands;

namespace Shop.Infrastructure.EF.Mapping.Brands
{
    public class BrandMapping:IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands", "dbo");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired().HasMaxLength(500);

            builder.Property(b => b.Logo)
                .HasMaxLength(110);

            builder.Property(b => b.MainImage)
                .HasMaxLength(110);
        }
    }
}