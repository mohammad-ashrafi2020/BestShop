using Account.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.Mapping.Users
{
    public class UserCardMap : IEntityTypeConfiguration<UserCard>
    {
        public void Configure(EntityTypeBuilder<UserCard> builder)
        {
            builder.ToTable("UserCards", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");


            builder.Property(b => b.AccountNumber)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(200);

            builder.Property(b => b.ShabaNumber)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(300);

            builder.Property(b => b.CardNumber)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(16);

            builder.Property(b => b.OwnerName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            builder.Property(b => b.BankName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            builder.HasOne(b => b.User)
                .WithMany(b => b.UserCards)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}