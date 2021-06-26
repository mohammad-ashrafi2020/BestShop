using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ValueObjects;

namespace Shop.Application.ProductCategories.ProductCategory.Commands.Edit
{
    public record EditProductCategoryCommand
        (int Id,string Slug, string Title, MetaValue MetaValue, bool ShowInMenu, IFormFile ImageFile) 
        : IBaseRequest;

}