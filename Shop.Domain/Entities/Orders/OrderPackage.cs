using System.Collections.Generic;
using _DomainUtils.Domain;
using Shop.Domain.Entities.Sellers;

namespace Shop.Domain.Entities.Orders
{
    public class OrderPackage:BaseEntity
    {
        public long OrderId { get; set; }
        public long SellerId { get; set; }
        public string PostTrackingCode { get; set; }
        public string SendType { get; set; }
        public int ShippingCost { get; set; }

        #region Relations
        public Order Order { get; set; }
        public Seller Seller { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}