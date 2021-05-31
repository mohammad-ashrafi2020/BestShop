using System.Collections.Generic;
using framework.Domain;

namespace Shop.Domain.Entities.Products.Category
{
    public class ProductCategorySpecification:BaseEntity
    {
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Hint { get; set; }

        #region Relations
        public ProductCategory ProductCategory { get; set; }
        public ICollection<ProductCategorySpecificationItem> Items { get; set; }
        #endregion
    }
}