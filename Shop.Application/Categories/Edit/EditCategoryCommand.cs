using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ValueObjects;

namespace Shop.Application.Categories.Edit
{
    public record EditCategoryCommand
        (int Id,string Slug, string Title, MetaValue MetaValue, bool ShowInMenu, IFormFile ImageFile) 
        : IBaseRequest;

}