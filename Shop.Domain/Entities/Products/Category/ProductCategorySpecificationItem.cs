using framework.Domain;

namespace Shop.Domain.Entities.Products.Category
{
    public class ProductCategorySpecificationItem:BaseEntity
    {
        public long CategorySpecificationId { get; set; }
        public string Title { get; set; }
        public string Hint { get; set; }


        #region Relations

        public ProductCategorySpecification CategorySpecification { get; set; }

        #endregion
    }
}