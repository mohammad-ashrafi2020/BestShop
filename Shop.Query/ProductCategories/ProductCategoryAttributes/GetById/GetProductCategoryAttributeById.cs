using Common.Application;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.ProductCategories.ProductCategoryAttributes.GetById
{
    public record GetProductCategoryAttributeById(long Id) : IBaseRequest<ProductCategoryAttributeDto>;
}