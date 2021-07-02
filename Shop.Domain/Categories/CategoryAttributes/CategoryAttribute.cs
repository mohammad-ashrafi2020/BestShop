using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.Categories.CategoryAttributes
{
    public class CategoryAttribute : BaseEntity<long>
    {
        public string Key { get; private set; }
        public int CategoryId { get; private set; }
        public string Hint { get; private set; }
        public long? ParentId { get; private set; }
        public int DisplayOrder { get; private set; }
        public bool ShowInLandingPage { get; private set; }

        [ForeignKey("ParentId")]
        public ICollection<CategoryAttribute> Children { get; set; }
        public Category Category { get; set; }


        private CategoryAttribute()
        {
            Children = new List<CategoryAttribute>();
        }
        public CategoryAttribute(string key, int categoryId, string hint, int displayOrder)
        {
            Validate(key);

            Key = key;
            CategoryId = categoryId;
            Hint = hint;
            DisplayOrder = displayOrder;
            Children = new List<CategoryAttribute>();
        }
        public void Edit(string key, string hint, int displayOrder)
        {
            Validate(key);

            Key = key;
            Hint = hint;
            DisplayOrder = displayOrder;
            ModifyDate = DateTime.Now;
        }

        public void AddChild(string kay, string hint, int displayOrder, bool showInLandingPage)
        {
            Children.Add(new CategoryAttribute(kay, CategoryId, hint, displayOrder)
            {
                ParentId = this.Id,
                ShowInLandingPage = showInLandingPage
            });
        }

        private static void Validate(string kay)
        {
            if (string.IsNullOrWhiteSpace(kay))
                throw new InvalidDomainDataException("کلید نمی تواند خالی باشد");

        }
    }
}