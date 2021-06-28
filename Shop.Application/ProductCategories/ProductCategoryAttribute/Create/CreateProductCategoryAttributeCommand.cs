using Common.Application;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.Create
{
    public record CreateProductCategoryAttributeCommand
        (string Key, string Hint, int DisplayOrder, int CategoryId, bool ShowInLandingPage, long? ParentId = null) : IBaseRequest;

}