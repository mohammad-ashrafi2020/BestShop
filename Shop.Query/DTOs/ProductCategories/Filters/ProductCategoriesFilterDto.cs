using System.Collections.Generic;
using Common.Core;

namespace Shop.Query.DTOs.ProductCategories.Filters
{
    public class ProductCategoriesFilterDto : BasePaging
    {
        public List<ProductCategoryDto> Categories { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
    }
}