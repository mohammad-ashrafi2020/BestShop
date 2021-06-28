using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.ProductCategories;
using Shop.Query.Mappers;

namespace Shop.Query.Categories.Category.GetById
{
    public class GetProductCategoryByIdQueryHandler:IBaseRequestHandler<GetProductCategoryById,CategoryDto>
    {
        private readonly ShopContext _db;

        public GetProductCategoryByIdQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<CategoryDto> Handle(GetProductCategoryById request, CancellationToken cancellationToken)
        {
            var res =await _db.Categories.FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken: cancellationToken);
           
            if (res == null)
                return null;

            return Mapper.MapCategory(res);
        }
    }
}