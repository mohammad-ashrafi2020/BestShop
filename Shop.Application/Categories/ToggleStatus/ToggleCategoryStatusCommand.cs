using Common.Application;

namespace Shop.Application.Categories.ToggleStatus
{
    public record ToggleCategoryStatusCommand(int Id) : IBaseRequest;
}