using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.ProductCategories.ProductCategoryAttributes.GetById
{
    public class GetProductCategoryAttributeByIdQueryHandler:IBaseRequestHandler<GetProductCategoryAttributeById, ProductCategoryAttributeDto>
    {
        private readonly ShopContext _db;

        public GetProductCategoryAttributeByIdQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<ProductCategoryAttributeDto> Handle(GetProductCategoryAttributeById request, CancellationToken cancellationToken)
        {
            var model = await _db.ProductCategoryAttributes.FirstOrDefaultAsync(f => f.Id == request.Id,
                cancellationToken: cancellationToken);
            if (model == null)
                return null;

            return new ProductCategoryAttributeDto()
            {
                CategoryId = model.CategoryId,
                DisplayOrder = model.DisplayOrder,
                Hint = model.Hint,
                Id = model.Id,
                IsActive = !model.IsDelete,
                Key = model.Key,
                ParentId = model.ParentId
            };
        }
    }
}