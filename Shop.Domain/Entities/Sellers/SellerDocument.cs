using framework.Domain;
using Shop.Domain.Enums;

namespace Shop.Domain.Entities.Sellers
{
    public class SellerDocument:BaseEntity
    {
        public long SellerId { get; set; }
        public string TypeName { get; set; }
        public string FileName { get; set; }

        #region Relation
        public Seller Seller { get; set; }
        #endregion
    }
}