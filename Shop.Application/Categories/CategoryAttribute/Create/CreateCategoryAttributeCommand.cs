using Common.Application;

namespace Shop.Application.Categories.CategoryAttribute.Create
{
    public record CreateCategoryAttributeCommand
        (string Key, string Hint, int DisplayOrder, int CategoryId, bool ShowInLandingPage, long? ParentId = null) : IBaseRequest;

}