namespace Blog.Domain.Entities.BlogPostGroupAggregate.Rules
{
    public interface IEnglishTitleUniquenessChecker
    {
        bool IsUnique(string englishTitle);
    }
}