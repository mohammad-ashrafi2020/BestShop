using Common.Application;
using Common.Core.Enums;
using Shop.Query.DTOs.ProductCategories.Filters;

namespace Shop.Query.ProductCategories.ProductCategory.GetByFilter
{
    public record GetProductCategoriesByFilterQuery(int PageId = 1, int Take = 20, string Title = null,
        string Slug = null) : IBaseQueryFilter<ProductCategoriesFilterDto>
    {
        public SearchOn SearchOn { get; set; } = SearchOn.All;
    }
}