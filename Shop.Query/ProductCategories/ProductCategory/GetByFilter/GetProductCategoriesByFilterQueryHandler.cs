using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Core.Enums;
using Common.Domain;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.ProductCategories;
using Shop.Query.DTOs.ProductCategories.Filters;
using Shop.Query.Utils.Specifications;

namespace Shop.Query.ProductCategories.ProductCategory.GetByFilter
{
    public class GetProductCategoriesByFilterQueryHandler : IBaseRequestHandler<GetProductCategoriesByFilterQuery, ProductCategoriesFilterDto>
    {
        private readonly ShopContext _db;

        public GetProductCategoriesByFilterQueryHandler(ShopContext db)
        {
            _db = db;
        }

   
        public async Task<ProductCategoriesFilterDto> Handle(GetProductCategoriesByFilterQuery request,
            CancellationToken cancellationToken)
        {
            var searchOn =
                new SearchOnSpecification<Domain.ProductCategories.ProductCategory.ProductCategory, int>(
                    request.SearchOn);

            var result = _db.ProductCategories.Specify(searchOn);

            if (!string.IsNullOrWhiteSpace(request.Title))
                result = result.Where(r => r.CategoryTitle.Contains(request.Title));

            if (!string.IsNullOrWhiteSpace(request.Slug))
                result = result.Where(r => r.CategoryTitle.Contains(request.Slug));

            var skip = (request.PageId - 1) * request.Take;
            var model = new ProductCategoriesFilterDto()
            {
                Slug = request.Slug,
                Title = request.Title,
                Categories = await result.Skip(skip).Take(request.Take).Select(s => new ProductCategoryDto()
                {
                    MetaValue = s.MetaValue,
                    ImageName = s.ImageName,
                    ParentId = s.ParentId,
                    Slug = s.Slug,
                    CategoryTitle = s.CategoryTitle,
                    ShowInMenu = s.ShowInMenu,
                    Id = s.Id,
                    IsActive = !s.IsDelete
                }).ToListAsync(cancellationToken: cancellationToken)
            };
            model.GeneratePaging(result, request.Take, request.PageId);
            return model;
        }
    }
}