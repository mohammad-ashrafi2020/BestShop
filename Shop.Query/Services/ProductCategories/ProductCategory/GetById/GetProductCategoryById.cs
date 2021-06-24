using Common.Application;
using MediatR;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.Services.ProductCategories.ProductCategory.GetById
{
    public record GetProductCategoryById(int CategoryId) : IBaseRequest<ProductCategoryDto>;

}