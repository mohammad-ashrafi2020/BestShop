using _DomainUtils.Domain;

namespace Shop.Domain.Entities.Orders
{
    public class OrderDetailInfo:BaseEntity
    {
        public long DetailId { get; set; }
        public string ProductName { get; set; }
        public long ProductId { get; set; }
        public long SellerId { get; set; }
        public string SellerName { get; set; }
        public string ColorName { get; set; }
        public int Count { get; set; }
        public int PricePerUnit { get; set; }


        public OrderDetail OrderDetail { get; set; }
    }
}