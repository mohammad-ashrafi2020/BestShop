using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Orders;

namespace Shop.Infrastructure.Mapping.Orders
{
    public class OrderDetailInfoMap : IEntityTypeConfiguration<OrderDetailInfo>
    {
        public void Configure(EntityTypeBuilder<OrderDetailInfo> builder)
        {
            builder.ToTable("OrderDetailInfos", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.ColorName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.ProductName)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(b => b.SellerName)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(b => b.OrderDetail)
                .WithOne(b => b.DetailInfo)
                .HasForeignKey<OrderDetailInfo>(b => b.DetailId);
        }
    }
}