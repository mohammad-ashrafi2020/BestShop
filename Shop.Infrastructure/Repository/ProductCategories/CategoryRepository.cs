using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Categories;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository.ProductCategories
{
    public class CategoryRepository : BaseRepository<int, Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }
    }
}