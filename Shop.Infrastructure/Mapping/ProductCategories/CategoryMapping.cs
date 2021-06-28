using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Categories;

namespace Shop.Infrastructure.EF.Mapping.ProductCategories
{
    public class CategoryMapping:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories","dbo");
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Slug);


            builder.Property(b => b.ImageName)
                .HasMaxLength(110);

            builder.Property(b => b.Slug)
                .IsRequired()
                .HasMaxLength(400)
                .IsUnicode(false);

            builder.Property(b => b.CategoryTitle)
                .IsRequired()
                .HasMaxLength(300);

            builder.OwnsOne(b => b.MetaValue, nav =>
            {
                nav.Property(b => b.Title)
                    .HasMaxLength(300);
                nav.Property(b => b.Description)
                    .HasMaxLength(400);
                nav.Property(b => b.KeyWords)
                    .HasMaxLength(400);
            });

        }
    }
}