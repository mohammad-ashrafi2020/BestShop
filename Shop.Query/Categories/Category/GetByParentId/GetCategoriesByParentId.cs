using System.Collections.Generic;
using Common.Application;
using Common.Core.Enums;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.Categories.Category.GetByParentId
{
    public record GetCategoriesByParentId(int ParentId) : IBaseQueryFilter<List<CategoryDto>>
    {
        public SearchOn SearchOn { get; set; }
    }
}