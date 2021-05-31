using Account.Domain.Entities.Users;
using Account.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.Mapping.Users
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.PhoneNumber).IsUnique();
            builder.HasIndex(b => b.Email).IsUnique();
            builder.HasIndex(b => b.NationalCode).IsUnique();

            builder.Property(b => b.NationalCode)
                .IsUnicode(false)
                .HasMaxLength(10);

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(11);

            builder.Property(b => b.Email)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(100);

            builder.Property(b => b.ActivationCode)
                .IsRequired(false)
                .HasMaxLength(10);

            builder.Property(b => b.ActivationToken)
                .IsRequired()
                .HasDefaultValueSql("NEWID()");

            builder.Property(b => b.ImageName)
                .IsRequired()
                .HasMaxLength(110)
                .HasDefaultValue("Default.jpg");

            builder.Property(b => b.Gender)
                .HasDefaultValue(Gender.None);

            builder.Property(b => b.Password)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(300);

            builder.Property(b => b.Family)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(b => b.Name)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");
        }
    }
}