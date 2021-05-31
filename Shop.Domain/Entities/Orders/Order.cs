using System;
using System.Collections.Generic;
using framework.Domain;
using Shop.Domain.Enums;

namespace Shop.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public long UserId { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
        public string DiscountTitle { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsFinally { get; set; }
        public bool IsPayByWallet { get; set; }

        #region Relation
        public ICollection<OrderPackage> OrderPackages { get; set; }
        public OrderAddress Address { get; set; }
        #endregion
    }
}