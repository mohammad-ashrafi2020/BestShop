namespace Blog.Domain.Entities.BlogPostAggregate.Rules
{
    public interface IPostSlugUniquenessChecker
    {
        bool IsUniq(string slug);
    }
}