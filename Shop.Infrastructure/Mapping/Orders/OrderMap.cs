using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Orders;
using Shop.Domain.Enums;

namespace Shop.Infrastructure.Mapping.Orders
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "dbo");
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.UserId).IsUnique(false);

            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.Status)
                .HasDefaultValue(OrderStatus.Suspended);

            builder.Property(b => b.Description)
                .IsRequired(false);

            builder.Property(b => b.DiscountTitle)
                .IsRequired(false)
                .HasMaxLength(200);

        }
    }
}