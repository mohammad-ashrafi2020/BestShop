using Common.Application;

namespace Shop.Application.ProductCategories.ProductCategory.ToggleStatus
{
    public record ProductCategoryToggleStatusCommand(int Id) : IBaseRequest;
}