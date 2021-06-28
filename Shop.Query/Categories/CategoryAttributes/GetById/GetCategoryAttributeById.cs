using Common.Application;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.Categories.CategoryAttributes.GetById
{
    public record GetCategoryAttributeById(long Id) : IBaseRequest<CategoryAttributeDto>;
}