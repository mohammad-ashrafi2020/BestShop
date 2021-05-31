using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Orders;
using Shop.Domain.Entities.Products;
using Shop.Domain.Entities.Products.Category;
using Shop.Domain.Entities.Products.Comments;
using Shop.Domain.Entities.Sellers;

namespace Shop.Infrastructure.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        #region Products
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCategorySpecification> ProductCategorySpecifications { get; set; }
        public DbSet<ProductCategorySpecificationItem> ProductCategorySpecificationItems { get; set; }

        #endregion

        #region Sellers

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerProduct> SellerProducts { get; set; }
        public DbSet<SellerStore> SellerStores { get; set; }
        public DbSet<SellerDocument> SellerDocuments { get; set; }
        public DbSet<SellerDocumentType> SellerDocumentTypes { get; set; }
        public DbSet<SellerRate> SellerRates { get; set; }
        public DbSet<SellerSendType> SellerSendTypes { get; set; }

        #endregion

        #region Orders

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAddress> OrderAddresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderPackage> OrderPackages { get; set; }
        public DbSet<OrderDetailInfo> OrderDetailInfos { get; set; }


        #endregion

    }
}