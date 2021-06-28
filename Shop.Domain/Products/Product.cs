using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.Brands;
using Shop.Domain.Products.ProductPictures;
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
        public ICollection<ProductPicture> ProductImages { get; set; }


        public Product()
        {
            
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