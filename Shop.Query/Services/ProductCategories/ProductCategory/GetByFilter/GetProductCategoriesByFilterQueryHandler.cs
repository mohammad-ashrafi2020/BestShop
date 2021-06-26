using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.ProductCategories;
using Shop.Query.DTOs.ProductCategories.Filters;

namespace Shop.Query.Services.ProductCategories.ProductCategory.GetByFilter
{
    public class GetProductCategoriesByFilterQueryHandler:IBaseRequestHandler<GetProductCategoriesByFilterQuery,ProductCategoriesFilterDto>
    {
        private readonly ShopContext _db;

        public GetProductCategoriesByFilterQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<ProductCategoriesFilterDto> Handle(GetProductCategoriesByFilterQuery request,
            CancellationToken cancellationToken)
        {
            var result = _db.ProductCategories.AsSplitQuery();
            if (string.IsNullOrWhiteSpace(request.Title))
                result = result.Where(r => r.CategoryTitle.Contains(request.Title));

            if (string.IsNullOrWhiteSpace(request.Slug))
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
                    ShowInMenu = s.ShowInMenu
                }).ToListAsync(cancellationToken)
            };
            model.GeneratePaging(result, request.Take, request.PageId);
            return model;
        }
    }
}