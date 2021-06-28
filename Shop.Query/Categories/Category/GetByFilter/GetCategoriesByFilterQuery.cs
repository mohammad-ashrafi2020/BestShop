using Common.Application;
using Common.Core.Enums;
using Shop.Query.DTOs.ProductCategories.Filters;

namespace Shop.Query.Categories.Category.GetByFilter
{
    public record GetCategoriesByFilterQuery(int PageId = 1, int Take = 20, string Title = null,
        string Slug = null) : IBaseQueryFilter<CategoriesFilterDto>
    {
        public SearchOn SearchOn { get; set; } = SearchOn.All;
    }
}