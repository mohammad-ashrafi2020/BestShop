using Common.Application;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.Create
{
    public record CreateProductCategoryAttributeCommand
        (string Key, string Hint, int DisplayOrder, int CategoryId, long? ParentId = null) : IBaseRequest;

}