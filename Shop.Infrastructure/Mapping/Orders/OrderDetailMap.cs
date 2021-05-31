using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Orders;

namespace Shop.Infrastructure.Mapping.Orders
{
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.Color)
                .HasMaxLength(300);

            builder.HasOne(b => b.SellerStore)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(b => b.SellerStoreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.OrderPackage)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(b => b.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}