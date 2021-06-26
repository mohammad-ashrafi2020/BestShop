using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductCategories.ProductCategory;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.ProductCategories
{
    public class ProductCategoryRepository : BaseRepository<int, ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ShopContext context) : base(context)
        {
        }
    }
}