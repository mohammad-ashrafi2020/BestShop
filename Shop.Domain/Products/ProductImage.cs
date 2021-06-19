using System;
using Common.Domain.Domain;

namespace Shop.Domain.Products
{
    public class ProductImage : BaseEntity
    {
        public ProductImage()
        {

        }
        public ProductImage(long productId, string imageName)
        {
            ProductId = productId;
            ImageName = imageName;
        }

        public void EditImage(string imageName)
        {
            ModifyDate = DateTime.Now;
            ImageName = imageName;
        }
        public long ProductId { get; private set; }
        public string ImageName { get; private set; }
    }
}