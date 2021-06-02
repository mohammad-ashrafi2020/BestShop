using _DomainUtils.Domain;

namespace Shop.Domain.Entities.Sellers
{
    public class SellerDocumentType:BaseEntity
    {
        public string TypeName { get; set; }
        public bool IsRequired { get; set; }

    }
}