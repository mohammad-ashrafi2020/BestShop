using Microsoft.EntityFrameworkCore;
using Shop.Domain.Brands;
using Shop.Domain.Categories;
using Shop.Domain.Categories.CategoryAttributes;
using Shop.Domain.Products;
using Shop.Domain.Products.ProductPictures;
using Shop.Domain.Products.ProductSpecifications;

namespace Shop.Infrastructure.EF.Context
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Config For Hi/Lo 
            modelBuilder.UseHiLo("Long_DBSequenceHiLo");
            modelBuilder.HasSequence<long>("Long_DBSequenceHiLo")
                .StartsAt(1).IncrementsBy(1);

            var assembly = typeof(ShopContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

           

            base.OnModelCreating(modelBuilder);
        }
    }
}