using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.Services.ProductCategories.ProductCategory.GetById
{
    public class GetProductCategoryByIdQueryHandler:IBaseRequestHandler<GetProductCategoryById,ProductCategoryDto>
    {
        private readonly ShopContext _db;

        public GetProductCategoryByIdQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<ProductCategoryDto> Handle(GetProductCategoryById request, CancellationToken cancellationToken)
        {
            var res =await _db.ProductCategories.FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken: cancellationToken);
            if (res == null)
                return null;

            return new ProductCategoryDto()
            {
                MetaValue = res.MetaValue,
                ImageName = res.ImageName,
                ParentId = res.ParentId,
                Slug = res.Slug,
                CategoryTitle = res.CategoryTitle,
                ShowInMenu = res.ShowInMenu
            };
        }
    }
}