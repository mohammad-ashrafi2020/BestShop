using framework.Domain;

namespace Shop.Domain.Entities.Sellers
{
    public class SellerSendType:BaseSoftDelete
    {
        public long SellerId { get; set; }
        public string SendTitle { get; set; }
        public int ShippingCost { get; set; }
        public int FreeWhenPriceUpperAs { get; set; }

        #region Relations
        public Seller Seller { get; set; }

        #endregion
    }
}