using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ValueObjects;

namespace Shop.Application.Categories.Create
{
    public record CreateCategoryCommand
        (string Slug,string Title,MetaValue MetaValue,bool ShowInMenu,int? ParentId,IFormFile ImageFile) 
        : IBaseRequest;


}