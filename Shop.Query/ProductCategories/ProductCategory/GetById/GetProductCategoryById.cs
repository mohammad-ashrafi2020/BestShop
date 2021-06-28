using Common.Application;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.ProductCategories.ProductCategory.GetById
{
    public record GetProductCategoryById(int CategoryId) : IBaseRequest<ProductCategoryDto>;

}