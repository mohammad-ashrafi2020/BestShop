using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF.Context;
using Shop.Query.Categories.CategoryAttributes.GetById;
using Shop.Query.DTOs.ProductCategories;
using Shop.Query.Mappers;

namespace Shop.Query.ProductCategories.ProductCategoryAttributes.GetById
{
    public class GetCategoryAttributeByIdQueryHandler:IBaseRequestHandler<GetCategoryAttributeById, CategoryAttributeDto>
    {
        private readonly ShopContext _db;

        public GetCategoryAttributeByIdQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<CategoryAttributeDto> Handle(GetCategoryAttributeById request, CancellationToken cancellationToken)
        {
            var model = await _db.CategoryAttributes.FirstOrDefaultAsync(f => f.Id == request.Id,
                cancellationToken: cancellationToken);
            if (model == null)
                return null;

            return Mapper.MapCategoryAttribute(model);
        }
    }
}