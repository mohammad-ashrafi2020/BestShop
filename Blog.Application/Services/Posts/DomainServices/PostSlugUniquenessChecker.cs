using System.Linq;
using Blog.Domain.Entities.BlogPostAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;

namespace Blog.Application.Services.Posts.DomainServices
{
    public class PostSlugUniquenessChecker: IPostSlugUniquenessChecker
    {
        private readonly BlogContext _context;

        public PostSlugUniquenessChecker(BlogContext context)
        {
            _context = context;
        }
        public bool IsUniq(string slug)
        {
            return !_context.BlogPosts.Any(b => b.Slug == slug);
        }
    }
}