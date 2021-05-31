using System.Collections.Generic;
using framework.Domain;
using Shop.Domain.Entities.Orders;

namespace Shop.Domain.Entities.Sellers
{
    public class SellerStore:BaseSoftDelete
    {
        public long SellerProductId { get; set; }
        public string ColorName { get; set; }
        public string ColorHaxCode { get; set; }
        public string GuaranteeName { get; set; }
        public int Count { get; set; }
        public bool IsOriginal { get; set; }
        public int Price { get; set; }
        public int? DiscountPercentage { get; set; }


        #region Relations
        public SellerProduct SellerProduct { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}