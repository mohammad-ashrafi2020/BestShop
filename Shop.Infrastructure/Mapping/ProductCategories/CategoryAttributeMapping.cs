using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Categories.CategoryAttributes;

namespace Shop.Infrastructure.EF.Mapping.ProductCategories
{
    public class CategoryAttributeMapping : IEntityTypeConfiguration<CategoryAttribute>
    {
        public void Configure(EntityTypeBuilder<CategoryAttribute> builder)
        {
            builder.ToTable("CategoryAttributes", "dbo");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Key)
                .IsRequired().HasMaxLength(300);

            builder.HasOne(b => b.Category)
                .WithMany(b => b.Attributes)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}