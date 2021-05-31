using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Products.Comments;

namespace Shop.Infrastructure.Mapping.Products.Comments
{
    public class ProductCommentMap : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.ToTable("ProductComments", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.Body)
                .IsRequired();

            builder.Property(b => b.Advantages)
                .IsRequired(false);

            builder.Property(b => b.Disadvantages)
                .IsRequired(false);

            builder.Property(b => b.IsActive)
                .HasDefaultValue(false);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(b => b.Product)
                .WithMany(b => b.Comments)
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}