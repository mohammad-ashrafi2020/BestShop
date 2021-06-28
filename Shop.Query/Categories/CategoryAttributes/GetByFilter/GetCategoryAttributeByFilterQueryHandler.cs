using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Categories.CategoryAttributes;
using Shop.Infrastructure.EF;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.ProductCategories;
using Shop.Query.Mappers;
using Shop.Query.Utils.Specifications;

namespace Shop.Query.Categories.CategoryAttributes.GetByFilter
{
    public class GetCategoryAttributeByFilterQueryHandler : IBaseRequestHandler<GetCategoryAttributeByFilter, List<CategoryAttributeDto>>
    {
        private readonly ShopContext _db;

        public GetCategoryAttributeByFilterQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<List<CategoryAttributeDto>> Handle(GetCategoryAttributeByFilter request, CancellationToken cancellationToken)
        {
            var searchOn = new SearchOnSpecification<CategoryAttribute, long>(request.SearchOn);

            var query = _db.CategoryAttributes
                .Specify(searchOn)
                .Where(c =>  c.CategoryId == request.CategoryId);


            return await query.Select(attribute=>Mapper.MapCategoryAttribute(attribute)
            ).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}