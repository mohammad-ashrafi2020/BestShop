using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.Brands;
using Shop.Query.Mappers;

namespace Shop.Query.Brands.BetById
{
    public class GetBrandByIdQueryHandler : IBaseRequestHandler<GetBrandById, BrandDto>
    {
        private readonly ShopContext _db;

        public GetBrandByIdQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<BrandDto> Handle(GetBrandById request, CancellationToken cancellationToken)
        {
            var model = await _db.Brands.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);

            return model == null ? null : Mapper.MapBrand(model);
        }
    }
}