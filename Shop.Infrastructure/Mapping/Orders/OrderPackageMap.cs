using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Orders;

namespace Shop.Infrastructure.Mapping.Orders
{
    public class OrderPackageMap : IEntityTypeConfiguration<OrderPackage>
    {
        public void Configure(EntityTypeBuilder<OrderPackage> builder)
        {
            builder.ToTable("OrderPackages", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.PostTrackingCode)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(b => b.SendType)
                .IsRequired(false)
                .HasMaxLength(400);

            builder.HasOne(b => b.Order)
                .WithMany(b => b.OrderPackages)
                .HasForeignKey(b => b.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}