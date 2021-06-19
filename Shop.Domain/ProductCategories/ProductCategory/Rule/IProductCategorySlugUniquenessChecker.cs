namespace Shop.Domain.ProductCategories.ProductCategory.Rule
{
    public interface IProductCategorySlugUniquenessChecker
    {
        bool IsUniq(string slug);
    }
}