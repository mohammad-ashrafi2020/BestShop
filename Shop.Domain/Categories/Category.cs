using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Core.Utilities;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.Categories.CategoryAttributes;
using Shop.Domain.Categories.Rule;
using Shop.Domain.ValueObjects;

namespace Shop.Domain.Categories
{
    public class Category : BaseEntity<int>
    {

        public string CategoryTitle { get; private set; }
        public string Slug { get; private set; }
        public MetaValue MetaValue { get; private set; }
        public string ImageName { get; private set; }
        public int? ParentId { get; private set; }
        public bool ShowInMenu { get; private set; }

        [ForeignKey("ParentId")]
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<CategoryAttribute> Attributes { get; set; }

        private Category()
        {
            SubCategories = new List<Category>();
        }
        public Category(string categoryTitle, string slug, MetaValue metaValue, string imageName, bool showInMenu, ICategorySlugUniquenessChecker _slugChecker)
        {
            Validate(categoryTitle, slug);

            if (_slugChecker.IsUniq(slug))
                throw new InvalidDomainDataException("Slug تکراری است");


            CategoryTitle = categoryTitle;
            Slug = slug.ToSlug();
            MetaValue = metaValue;
            ImageName = imageName;
            ShowInMenu = showInMenu;
            Attributes = new List<CategoryAttribute>();
            SubCategories = new List<Category>();
        }

        public void Edit(string categoryTitle, string slug, string imageName, MetaValue metaValue,bool shoInMenu, ICategorySlugUniquenessChecker _slugChecker)
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

        public void AddChild(string slug, string groupTitle, string imageName, MetaValue metaValue, bool showInMenu, ICategorySlugUniquenessChecker _slugChecker)
        {
            var category = new Category(groupTitle, slug, metaValue, imageName, showInMenu, _slugChecker)
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