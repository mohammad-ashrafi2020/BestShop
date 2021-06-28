using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Brands;
using Shop.Infrastructure.EF;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.Brands;
using Shop.Query.Mappers;
using Shop.Query.Utils.Specifications;

namespace Shop.Query.Brands.GetByFilter
{
    public class GetBrandByFilterQueryHandler : IBaseRequestHandler<GetBrandByFilter, List<BrandDto>>
    {
        private readonly ShopContext _db;

        public GetBrandByFilterQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<List<BrandDto>> Handle(GetBrandByFilter request, CancellationToken cancellationToken)
        {
            var searchOn = new SearchOnSpecification<Brand, int>(request.SearchOn);
            var query = _db.Brands.Specify(searchOn);
            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(q => q.Name.Contains(request.Name));

            return await query.Select(brand => Mapper.MapBrand(brand))
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}