
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Domain.Repository;

namespace Shop.Domain.Products
{
    public interface IProductRepository : IBaseRepository<long, Product>
    {
        Task SetProductCategories(List<ProductCategory> categories);
    }
}