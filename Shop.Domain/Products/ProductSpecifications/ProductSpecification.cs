using System;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain;
using Shop.Domain.Categories.CategoryAttributes;

namespace Shop.Domain.Products.ProductSpecifications
{
    public class ProductSpecification : BaseEntity<long>
    {
        public long ProductId { get; private set; }
        public long CategoryAttributeId { get; private set; }
        public string Value { get; private set; }


        public Product Product { get; set; }
        [ForeignKey("CategoryAttributeId")]
        public CategoryAttribute CategoryAttribute { get; set; }


        public ProductSpecification(long categoryAttributeId, string value, long productId)
        {
            CategoryAttributeId = categoryAttributeId;
            Value = value;
            ProductId = productId;
        }

        public void Edit(string value)
        {
            Value = value;
            ModifyDate = DateTime.Now;
        }
    }
}