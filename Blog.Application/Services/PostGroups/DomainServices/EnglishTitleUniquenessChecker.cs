using System.Linq;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;

namespace Blog.Application.Services.PostGroups.DomainServices
{
    public class EnglishTitleUniquenessChecker : IEnglishTitleUniquenessChecker
    {
        private BlogContext _db;

        public EnglishTitleUniquenessChecker(BlogContext db)
        {
            _db = db;
        }

        public bool IsUnique(string englishTitle)
        {
            return !_db.BlogPostGroups.Any(g => g.EnglishGroupTitle == englishTitle.ToLower());
        }
    }
}