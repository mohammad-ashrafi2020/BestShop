using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductCategories.ProductCategory;
using Shop.Domain.ProductCategories.ProductCategoryAttributes;
using Shop.Domain.Products;

namespace Shop.Infrastructure.EF.Context
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
            
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCategoryAttribute> ProductCategoryAttributes { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ShopContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}