using System.Reflection;
using Account.Domain.Entities.Roles;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Mapping;
using Account.Infrastructure.Mapping.Users;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Context
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserCard> UserCards { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserWallet> UserWallets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountContext).Assembly);
        
        }
    }
}