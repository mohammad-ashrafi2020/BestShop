using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Core.Utilities;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Shop.Domain.ProductCategories.ProductCategory.Rule;
using Shop.Domain.ProductCategories.ProductCategoryAttributes;
using Shop.Domain.ValueObjects;

namespace Shop.Domain.ProductCategories.ProductCategory
{
    public class ProductCategory : BaseEntity<int>
    {

        public string CategoryTitle { get; private set; }
        public string Slug { get; private set; }
        public MetaValue MetaValue { get; private set; }
        public string ImageName { get; private set; }
        public int? ParentId { get; private set; }
        public bool ShowInMenu { get; private set; }

        [ForeignKey("ParentId")]
        public ICollection<ProductCategory> SubCategories { get; set; }
        public ICollection<ProductCategoryAttribute> Attributes { get; set; }

        private ProductCategory()
        {
            SubCategories = new List<ProductCategory>();
        }
        public ProductCategory(string categoryTitle, string slug, MetaValue metaValue, string imageName, bool showInMenu, IProductCategorySlugUniquenessChecker _slugChecker)
        {
            Validate(categoryTitle, slug);

            if (_slugChecker.IsUniq(slug))
                throw new InvalidDomainDataException("Slug تکراری است");


            CategoryTitle = categoryTitle;
            Slug = slug.ToSlug();
            MetaValue = metaValue;
            ImageName = imageName;
            ShowInMenu = showInMenu;
            Attributes = new List<ProductCategoryAttribute>();
            SubCategories = new List<ProductCategory>();
        }

        public void Edit(string categoryTitle, string slug, string imageName, MetaValue metaValue,bool shoInMenu, IProductCategorySlugUniquenessChecker _slugChecker)
        {
            Validate(categoryTitle, slug);

            if (slug != Slug)
                if (_slugChecker.IsUniq(slug))
                    throw new InvalidDomainDataException("Slug تکراری است");

            CategoryTitle = categoryTitle;
            Slug = slug.ToSlug();
            ImageName = imageName;
            MetaValue = metaValue;
            ShowInMenu = shoInMenu;
            ModifyDate = DateTime.Now;
        }

        public void AddChild(string slug, string groupTitle, string imageName, MetaValue metaValue, bool showInMenu, IProductCategorySlugUniquenessChecker _slugChecker)
        {
            var category = new ProductCategory(groupTitle, slug, metaValue, imageName, showInMenu, _slugChecker)
            {
                ParentId = Id
            };
            SubCategories.Add(category);
        }



        private static void Validate(string categoryTitle, string slug)
        {
            if (string.IsNullOrEmpty(slug))
                throw new InvalidDomainDataException("slug Is Null");

            if (slug.IsUniCode())
                throw new InvalidDomainDataException("Slug فقط قادر به ذخیره  حروف انگلیسی می باشد");

            if (string.IsNullOrEmpty(categoryTitle))
                throw new InvalidDomainDataException("عنوان دسته بندی را وارد کنید");

        }
    }
}