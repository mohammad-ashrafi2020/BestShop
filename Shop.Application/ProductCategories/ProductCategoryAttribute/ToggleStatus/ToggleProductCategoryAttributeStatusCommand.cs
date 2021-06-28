using Common.Application;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.ToggleStatus
{
    public record ToggleProductCategoryAttributeStatusCommand(long Id) : IBaseRequest;
}