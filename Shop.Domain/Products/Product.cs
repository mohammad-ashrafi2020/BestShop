using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.Brands;
using Shop.Domain.Products.ProductPictures;
using Shop.Domain.Products.ProductSpecifications;
using Shop.Domain.ValueObjects;

namespace Shop.Domain.Products
{
    public class Product : BaseEntity<long>
    {
        public int BrandId { get; set; }
        public string EnglishName { get; private set; }
        public string PersianName { get; private set; }
        public string ShortDescription { get; private set; }
        public string FullDescription { get; private set; }
        public MetaValue MetaValue { get; private set; }
        public string ImageName { get; private set; }
        public string BitMapImageName { get; private set; }

        public Brand Brand { get; set; }
        public ICollection<ProductSpecification> ProductSpecifications { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

        public Product()
        {
            ProductCategories = new List<ProductCategory>();
        }
        public Product(string englishName, string persianName, string shortDescription, string fullDescription, MetaValue metaValue, string imageName, string bitMapImageName)
        {
            Validate(englishName, persianName, shortDescription, fullDescription);

            EnglishName = englishName;
            PersianName = persianName;
            ShortDescription = shortDescription;
            FullDescription = fullDescription;
            MetaValue = metaValue;
            ImageName = imageName ?? "Default.png";
            BitMapImageName = bitMapImageName ?? "Default.png";
            ProductCategories = new List<ProductCategory>();
        }
        public void Edit(string englishName, string persianName, string shortDescription, string fullDescription, MetaValue metaValue, string imageName, string bitMapImageName)
        {
            Validate(englishName, persianName, shortDescription, fullDescription);

            EnglishName = englishName;
            PersianName = persianName;
            ShortDescription = shortDescription;
            FullDescription = fullDescription;
            MetaValue = metaValue;
            ModifyDate = DateTime.Now;
        }

        public void EditImage(string imageName)
        {
            ImageName = imageName;
            ModifyDate = DateTime.Now;
        }
        public void EditBitMapImage(string bitMapImageName)
        {
            BitMapImageName = bitMapImageName;
            ModifyDate = DateTime.Now;
        }

        public void SetCategories(List<ProductCategory> categories)
        {
            ProductCategories.Clear();
            foreach (var category in categories)
            {
                ProductCategories.Add(new ProductCategory(Id, category.CategoryId, category.Level));
            }
        }

        private static void Validate(string englishName, string persianName, string shortDescription, string fullDescription)
        {
            if (string.IsNullOrWhiteSpace(englishName))
                throw new InvalidDomainDataException($"{nameof(EnglishName)} Is Empty");

            if (string.IsNullOrWhiteSpace(persianName))
                throw new InvalidDomainDataException($"{nameof(PersianName)} Is Empty");

            if (string.IsNullOrWhiteSpace(shortDescription))
                throw new InvalidDomainDataException($"{nameof(ShortDescription)} Is Empty");

            if (string.IsNullOrWhiteSpace(fullDescription))
                throw new InvalidDomainDataException($"{nameof(FullDescription)} Is Empty");

        }
    }
}