using Common.Application;
using Common.Core.Utilities;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Brands.Edit
{
    public record EditBrandCommand(int Id, string Name, IFormFile LogoFile, IFormFile ImageFile) : IBaseRequest;
}