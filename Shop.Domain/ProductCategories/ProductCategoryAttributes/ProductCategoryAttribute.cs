using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using _DomainUtils.Domain;
using _DomainUtils.Exceptions;

namespace Shop.Domain.ProductCategories.ProductCategoryAttributes
{
    public class ProductCategoryAttribute : BaseEntity<long>
    {
        private ProductCategoryAttribute()
        {
        }
        
        public string Key { get; private set; }
        public int CategoryId { get; private set; }
        public string Hint { get; private set; }
        public long? ParentId { get; private set; }
        public int DisplayOrder { get; private set; }

        [ForeignKey("ParentId")]
        public ICollection<ProductCategoryAttribute> Children { get; set; }
        public ProductCategory.ProductCategory ProductCategory { get; set; }

        public ProductCategoryAttribute(string key, int categoryId, string hint, int displayOrder)
        {
            Validate(key);

            Key = key;
            CategoryId = categoryId;
            Hint = hint;
            DisplayOrder = displayOrder;
            Children = new List<ProductCategoryAttribute>();
        }
        public void Edit(string key, string hint, int displayOrder)
        {
            Validate(key);

            Key = key;
            Hint = hint;
            DisplayOrder = displayOrder;
        }

        public void AddChild(string kay, string hint, int displayOrder)
        {
            Children.Add(new ProductCategoryAttribute(kay,CategoryId,hint, displayOrder)
            {
                ParentId = this.Id
            });
        }

        private static void Validate(string kay)
        {
            if (string.IsNullOrWhiteSpace(kay))
                throw new InvalidDomainDataException("کلید نمی تواند خالی باشد");

        }
    }
}