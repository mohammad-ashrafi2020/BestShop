using Common.Domain;

namespace Shop.Domain.Products.ProductSpecification
{
    public class ProductSpecification : BaseEntity<long>
    {
        public long CategoryAttribute { get; set; }
        public string Value { get; set; }
    }
}