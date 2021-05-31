using Account.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.Mapping.Users
{
    public class UserAddressMap : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddresses", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.Address)
                .IsRequired();

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Family)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Shire)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.PostalCode)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            builder.Property(b => b.NationalCode)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(10);

            builder.Property(b => b.Phone)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(11);

            builder.HasOne(b => b.User)
                .WithMany(b => b.UserAddresses)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}