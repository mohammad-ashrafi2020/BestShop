using Account.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.Mapping.Users
{
    public class UserWalletMap : IEntityTypeConfiguration<UserWallet>
    {
        public void Configure(EntityTypeBuilder<UserWallet> builder)
        {
            builder.ToTable("UserWallets", "dbo");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(b => b.BankTrackingCode)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.HasOne(b => b.User)
                .WithMany(b => b.Wallets)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}