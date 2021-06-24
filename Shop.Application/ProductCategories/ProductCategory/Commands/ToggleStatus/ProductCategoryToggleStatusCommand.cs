using Common.Application;

namespace Shop.Application.ProductCategories.ProductCategory.Commands.ToggleStatus
{
    public record ProductCategoryToggleStatusCommand(int Id) : ICommitTableRequest, IBaseRequest;
}