using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using _DomainUtils.Domain;
using _DomainUtils.Exceptions;
using _DomainUtils.Utils;
using Shop.Domain.ProductCategories.ProductCategoryAttributes;
using Shop.Domain.ProductCategoryAgg.Rule;
using Shop.Domain.ValueObjects;

namespace Shop.Domain.ProductCategories.ProductCategory
{
    public class ProductCategory : BaseEntity<int>
    {
        private ProductCategory()
        {

        }
        public string CategoryTitle { get; private set; }
        public string Slug { get; private set; }
        public MetaValue MetaValue { get; set; }
        public string ImageName { get; private set; }
        public int? ParentId { get; private set; }
        public bool ShowInMenu { get; private set; }

        [ForeignKey("ParentId")]
        public ICollection<ProductCategory> SubCategories { get; set; }
        public ICollection<ProductCategoryAttribute> Attributes { get; set; }

        public ProductCategory(string categoryTitle, string slug, MetaValue metaValue, string imageName, bool showInMenu, IProductCategorySlugUniquenessChecker _slugChecker)
        {
            Validate(categoryTitle, slug, _slugChecker);


            CategoryTitle = categoryTitle;
            Slug = slug.Domain_ToSlug();
            MetaValue = metaValue;
            ImageName = imageName;
            ShowInMenu = showInMenu;
            Attributes = new List<ProductCategoryAttribute>();
            SubCategories = new List<ProductCategory>();
        }

        public void Edit(string categoryTitle, string slug, string imageName, MetaValue metaValue, IProductCategorySlugUniquenessChecker _slugChecker)
        {
            Validate(categoryTitle, slug, _slugChecker);


            CategoryTitle = categoryTitle;
            Slug = slug.Domain_ToSlug();
            ImageName = imageName;
            MetaValue = metaValue;
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



        private static void Validate(string categoryTitle, string slug, IProductCategorySlugUniquenessChecker _slugChecker)
        {
            if (string.IsNullOrEmpty(slug))
                throw new InvalidDomainDataException("slug Is Null");

            if (slug.Domain_IsUniCode())
                throw new InvalidDomainDataException("Slug فقط قادر به ذخیره  حروف انگلیسی می باشد");

            if (_slugChecker.IsUniq(slug))
                throw new InvalidDomainDataException("This Slug Exist In Database");

            if (string.IsNullOrEmpty(categoryTitle))
                throw new InvalidDomainDataException("عنوان دسته بندی را وارد کنید");

        }
    }
}