using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Brands.Create
{
    public record CreateBrandCommand(string Name, IFormFile LogoFile, IFormFile ImageFile) : IBaseRequest;
}