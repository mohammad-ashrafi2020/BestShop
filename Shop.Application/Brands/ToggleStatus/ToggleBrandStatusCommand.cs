using MediatR;
using IBaseRequest = Common.Application.IBaseRequest;

namespace Shop.Application.Brands.ToggleStatus
{
    public record ToggleBrandStatusCommand(int Id) : IBaseRequest;
}