using _DomainUtils.Domain;
using Shop.Domain.Entities.Sellers;

namespace Shop.Domain.Entities.Orders
{
    public class OrderDetail:BaseEntity
    {
        public long PackageId { get; set; }
        public long SellerStoreId { get; set; }
        public string Color { get; set; }
        public int Count { get; set; }
        public int PricePerUnit { get; set; }


        #region Relations
        public OrderPackage OrderPackage { get; set; }
        public SellerStore SellerStore { get; set; }
        public OrderDetailInfo DetailInfo { get; set; }
        #endregion
    }
}