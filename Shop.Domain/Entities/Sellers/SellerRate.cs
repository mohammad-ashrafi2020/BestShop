using framework.Domain;
using Shop.Domain.Enums;

namespace Shop.Domain.Entities.Sellers
{
    public class SellerRate:BaseEntity
    {
        public long SellerId { get; set; }
        public long UserId { get; set; }
        public int Rate { get; set; }
        public RateType RateType { get; set; }


        #region Relations
        public Seller Seller { get; set; }
        #endregion
    }
}