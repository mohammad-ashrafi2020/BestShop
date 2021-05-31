using Account.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.Mapping.Users
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");


            builder.HasOne(b => b.Role)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(b => b.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}