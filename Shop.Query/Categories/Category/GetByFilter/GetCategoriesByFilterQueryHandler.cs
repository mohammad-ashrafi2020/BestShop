using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.ProductCategories.Filters;
using Shop.Query.Mappers;
using Shop.Query.Utils.Specifications;

namespace Shop.Query.Categories.Category.GetByFilter
{
    public class GetCategoriesByFilterQueryHandler : IBaseRequestHandler<GetCategoriesByFilterQuery, CategoriesFilterDto>
    {
        private readonly ShopContext _db;

        public GetCategoriesByFilterQueryHandler(ShopContext db)
        {
            _db = db;
        }


        public async Task<CategoriesFilterDto> Handle(GetCategoriesByFilterQuery request,
            CancellationToken cancellationToken)
        {
            var searchOn =
                new SearchOnSpecification<Domain.Categories.Category, int>(
                    request.SearchOn);

            var result = _db.Categories.Specify(searchOn);

            if (!string.IsNullOrWhiteSpace(request.Title))
                result = result.Where(r => r.CategoryTitle.Contains(request.Title));

            if (!string.IsNullOrWhiteSpace(request.Slug))
                result = result.Where(r => r.CategoryTitle.Contains(request.Slug));

            var skip = (request.PageId - 1) * request.Take;
            var model = new CategoriesFilterDto()
            {
                Slug = request.Slug,
                Title = request.Title,
                Categories = await result.Skip(skip).Take(request.Take).Select(category
                    => Mapper.MapCategory(category)).ToListAsync(cancellationToken)
            };
            model.GeneratePaging(result, request.Take, request.PageId);
            return model;
        }
    }
}