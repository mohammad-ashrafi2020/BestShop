using Common.Domain;
using Shop.Domain.Categories;

namespace Shop.Domain.Products
{
    public class ProductCategory : BaseEntity<long>
    {
        public ProductCategory(long productId, int categoryId, CategoryLevel level)
        {
            ProductId = productId;
            CategoryId = categoryId;
            Level = level;
        }

        public long ProductId { get; private set; }
        public int CategoryId { get; private set; }
        public CategoryLevel Level { get; private set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }

    public enum CategoryLevel
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4
    }
}