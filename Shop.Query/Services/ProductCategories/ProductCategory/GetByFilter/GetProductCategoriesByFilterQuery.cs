using Common.Application;
using Shop.Query.DTOs.ProductCategories.Filters;

namespace Shop.Query.Services.ProductCategories.ProductCategory.GetByFilter
{
    public record GetProductCategoriesByFilterQuery(int PageId = 1, int Take = 20, string Title = null,
        string Slug = null) : IBaseRequest<ProductCategoriesFilterDto>;

}