using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ValueObjects;

namespace Shop.Application.ProductCategories.ProductCategory.Create
{
    public record CreateProductCategoryCommand
        (string Slug,string Title,MetaValue MetaValue,bool ShowInMenu,int? ParentId,IFormFile ImageFile) 
        : IBaseRequest;


}