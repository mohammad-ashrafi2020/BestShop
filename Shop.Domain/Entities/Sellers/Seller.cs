using System.Collections.Generic;
using framework.Domain;

namespace Shop.Domain.Entities.Sellers
{
    public class Seller : BaseSoftDelete
    {
        public long UserId { get; set; }
        public string ShopName { get; set; }
        public string NationalCode { get; set; }
        public string ShopImage { get; set; }
        public string ShortLink { get; set; }
        public bool IsApprovedByUs { get; set; }
        public bool IsActive { get; set; }


        #region Relation
        public ICollection<SellerDocument> SellerDocuments { get; set; }
        public ICollection<SellerProduct> SellerProducts { get; set; }
        public ICollection<SellerSendType> SendType { get; set; }
        public ICollection<SellerRate> Rates { get; set; }
        #endregion
    }
}