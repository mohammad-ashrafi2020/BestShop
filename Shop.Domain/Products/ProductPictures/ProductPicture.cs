using System;
using Common.Domain.Domain;

namespace Shop.Domain.Products.ProductPictures
{
    public class ProductPicture : BaseEntity<long>
    {
        public ProductPicture()
        {

        }
        public ProductPicture(long productId, string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
                throw new Exception("ImageName Is Null");

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
        public int DisplayOrder { get; set; }
    }
}