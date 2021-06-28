using System.Collections.Generic;
using Common.Application;
using Common.Core.Enums;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.Categories.CategoryAttributes.GetByFilter
{
    public record GetCategoryAttributeByFilter(int CategoryId) : IBaseQueryFilter<List<CategoryAttributeDto>>
    {
        public SearchOn SearchOn { get; set; } = SearchOn.All;
    }
}