namespace Shop.Domain.Categories.Rule
{
    public interface ICategorySlugUniquenessChecker
    {
        bool IsUniq(string slug);
    }
}