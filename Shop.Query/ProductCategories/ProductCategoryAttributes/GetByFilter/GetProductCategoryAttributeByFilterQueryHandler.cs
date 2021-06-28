using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductCategories.ProductCategoryAttributes;
using Shop.Infrastructure.EF;
using Shop.Infrastructure.EF.Context;
using Shop.Query.DTOs.ProductCategories;
using Shop.Query.Utils.Specifications;

namespace Shop.Query.ProductCategories.ProductCategoryAttributes.GetByFilter
{
    public class GetProductCategoryAttributeByFilterQueryHandler : IBaseRequestHandler<GetProductCategoryAttributeByFilter, List<ProductCategoryAttributeDto>>
    {
        private readonly ShopContext _db;

        public GetProductCategoryAttributeByFilterQueryHandler(ShopContext db)
        {
            _db = db;
        }

        public async Task<List<ProductCategoryAttributeDto>> Handle(GetProductCategoryAttributeByFilter request, CancellationToken cancellationToken)
        {
            var searchOn = new SearchOnSpecification<ProductCategoryAttribute, long>(request.SearchOn);

            var query = _db.ProductCategoryAttributes
                .Specify(searchOn)
                .Where(c =>  c.CategoryId == request.CategoryId);


            return await query.Select(s => new ProductCategoryAttributeDto()
            {
                CategoryId = s.CategoryId,
                DisplayOrder = s.DisplayOrder,
                Hint = s.Hint,
                Id = s.Id,
                Key = s.Key,
                IsActive = !s.IsDelete,
                ParentId = s.ParentId
            }).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}