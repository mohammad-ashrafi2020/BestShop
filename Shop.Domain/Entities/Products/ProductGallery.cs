using _DomainUtils.Domain;

namespace Shop.Domain.Entities.Products
{
    public class ProductGallery:BaseEntity
    {
        public long ProductId { get; set; }
        public string ImageName { get; set; }


        #region Relations

        public Product Product { get; set; }

        #endregion
    }
}