using System.Collections.Generic;
using framework.Domain;
using Shop.Domain.Entities.Products.Category;
using Shop.Domain.Entities.Products.Comments;

namespace Shop.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public string BannerImage { get; set; }
        public string ImageName { get; set; }
        public string ImageAlt { get; set; }
        public string Warning { get; set; }
        public string ShortLink { get; set; }
        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
        public long SecondSubCategoryId { get; set; }
        public bool IsActive { get; set; }


        #region Relations
        public ICollection<ProductGallery> ProductGalleries { get; set; }
        public ICollection<ProductComment> Comments { get; set; }
        public ICollection<ProductSpecification> ProductSpecifications { get; set; }
        public ProductCategory Category { get; set; }
        public ProductCategory SubCategory { get; set; }
        public ProductCategory SecondSubCategory { get; set; }
        #endregion
    }
}