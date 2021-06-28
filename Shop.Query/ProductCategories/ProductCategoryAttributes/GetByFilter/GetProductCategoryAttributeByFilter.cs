using System.Collections.Generic;
using Common.Application;
using Common.Core.Enums;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.ProductCategories.ProductCategoryAttributes.GetByFilter
{
    public record GetProductCategoryAttributeByFilter(int CategoryId) : IBaseQueryFilter<List<ProductCategoryAttributeDto>>
    {
        public SearchOn SearchOn { get; set; } = SearchOn.All;
    }
}