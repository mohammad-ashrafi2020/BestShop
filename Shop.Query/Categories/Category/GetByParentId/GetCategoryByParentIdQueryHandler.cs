using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.ProductCategories;
using Shop.Query.Mappers;
using Shop.Query.Utils.Specifications;

namespace Shop.Query.Categories.Category.GetByParentId
{
    public class GetCategoryByParentIdQueryHandler : IBaseRequestHandler<GetCategoriesByParentId, List<CategoryDto>>
    {
        private readonly ShopContext _db;

        public GetCategoryByParentIdQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesByParentId request, CancellationToken cancellationToken)
        {
            var searchOn = new SearchOnSpecification<Domain.Categories.Category, int>(request.SearchOn);

            var query = _db.Categories.Specify(searchOn).Where(c => c.ParentId == request.ParentId);

            return await query.Select(category => Mapper.MapCategory(category)
            ).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}