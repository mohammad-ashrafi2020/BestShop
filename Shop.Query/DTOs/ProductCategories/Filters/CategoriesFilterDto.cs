using System.Collections.Generic;
using Common.Core;

namespace Shop.Query.DTOs.ProductCategories.Filters
{
    public class CategoriesFilterDto : BasePaging
    {
        public List<CategoryDto> Categories { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
    }
}