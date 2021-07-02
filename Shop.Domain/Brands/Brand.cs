using System.Collections.Generic;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.Products;

namespace Shop.Domain.Brands
{
    public class Brand : BaseEntity<int>
    {
        public Brand()
        {
            
        }
        public Brand(string name,string mainImage, string logo)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidDomainDataException("نام برند را وارد کیند");

            MainImage = mainImage ?? "Default.png";
            Name = name;
            Logo = logo ?? "Default.png";
        }

        public void Edit(string name, string mainImage, string logo)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidDomainDataException("نام برند را وارد کیند");

            MainImage = mainImage ?? MainImage;
            Name = name;
            Logo = logo ?? Logo;
        }
        public string Name { get; private set; }
        public string MainImage { get; private set; }
        public string Logo { get; private set; }
        public ICollection<Product> Products { get; set; }
    }
}