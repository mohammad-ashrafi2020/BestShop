namespace Shop.Domain.ProductCategoryAgg.Rule
{
    public interface IProductCategorySlugUniquenessChecker
    {
        bool IsUniq(string slug);
    }
}