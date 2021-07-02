using System;
using Common.Domain;

namespace Shop.Domain.Products.ProductPictures
{
    public class ProductPicture : BaseEntity<long>
    {
       
        public long ProductId { get; private set; }
        public string ImageName { get; private set; }
        public string ImageAlt { get; private set; }
        public int DisplayOrder { get; private set; }

        public Product Product { get; set; }


        public ProductPicture(long productId, string imageName, int displayOrder, string imageAlt)
        {
            if (string.IsNullOrEmpty(imageName))
                throw new Exception("ImageName Is Null");

            ProductId = productId;
            ImageName = imageName;
            DisplayOrder = displayOrder;
            ImageAlt = imageAlt;
        }

        public void EditImage(string imageName, int displayOrder, string imageAlt)
        {
            ModifyDate = DateTime.Now;
            ImageName = imageName;
        }
    }
}