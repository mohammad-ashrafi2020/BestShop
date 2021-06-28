using Common.Application;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.Edit
{
    public record EditProductCategoryAttributeCommand(long Id, string Key, string Hint, int DisplayOrder) : IBaseRequest;
}