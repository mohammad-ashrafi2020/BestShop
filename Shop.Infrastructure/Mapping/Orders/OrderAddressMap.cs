using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Orders;

namespace Shop.Infrastructure.Mapping.Orders
{
    public class OrderAddressMap : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.ToTable("OrderAddresses", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(b => b.NationalCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(b => b.PostalCode)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Family)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Shire)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.City)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Village)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Address)
                .IsRequired();

            builder.Property(b => b.Plaque)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(b => b.Order)
                .WithOne(b => b.Address)
                .HasForeignKey<OrderAddress>(a => a.OrderId);
        }
    }
}