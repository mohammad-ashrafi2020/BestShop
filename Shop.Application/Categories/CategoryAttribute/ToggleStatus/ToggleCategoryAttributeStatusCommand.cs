using Common.Application;

namespace Shop.Application.Categories.CategoryAttribute.ToggleStatus
{
    public record ToggleCategoryAttributeStatusCommand(long Id) : IBaseRequest;
}