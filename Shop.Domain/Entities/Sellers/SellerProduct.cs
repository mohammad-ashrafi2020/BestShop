using System.Collections.Generic;
using framework.Domain;
using Shop.Domain.Entities.Products;

namespace Shop.Domain.Entities.Sellers
{
    public class SellerProduct:BaseEntity
    {
        public long ProductId { get; set; }
        public long SellerId { get; set; }

        #region Relations
        public Product Product { get; set; }
        public Seller Seller { get; set; }
        public ICollection<SellerStore> SellerStores { get; set; }
        #endregion
    }
}