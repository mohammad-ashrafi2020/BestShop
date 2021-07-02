using Common.Application;

namespace Shop.Application.Categories.CategoryAttribute.Edit
{
    public record EditCategoryAttributeCommand(long Id, string Key, string Hint, int DisplayOrder) : IBaseRequest;
}