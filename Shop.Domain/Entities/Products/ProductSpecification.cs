using framework.Domain;
using Shop.Domain.Entities.Products.Category;

namespace Shop.Domain.Entities.Products
{
    public class ProductSpecification:BaseEntity
    {
        public long CategorySpecificationId { get; set; }
        public long ProductId { get; set; }
        public string Value { get; set; }
        public string Hint { get; set; }


        #region Relation
        public ProductCategorySpecificationItem SpecificationItem { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}