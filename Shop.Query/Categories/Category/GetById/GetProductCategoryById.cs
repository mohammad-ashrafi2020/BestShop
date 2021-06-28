using Common.Application;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.Categories.Category.GetById
{
    public record GetProductCategoryById(int CategoryId) : IBaseRequest<CategoryDto>;

}