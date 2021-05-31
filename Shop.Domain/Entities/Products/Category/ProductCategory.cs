using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using framework.Domain;

namespace Shop.Domain.Entities.Products.Category
{
    public class ProductCategory : BaseEntity
    {
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string ImageName { get; set; }
        public long? ParentId { get; set; }

        #region Relations
        [ForeignKey("ParentId")]
        public ProductCategory Parent { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Product> SubProducts { get; set; }
        public ICollection<Product> SecondSubProducts { get; set; }
        public ICollection<ProductCategorySpecification> Specifications { get; set; }
        #endregion
    }
}