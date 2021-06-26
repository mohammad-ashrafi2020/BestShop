using Blog.Application.Services.PostGroups.Queries.DTOs;
using Common.Application;

namespace Blog.Application.Services.PostGroups.Queries.GetByEnglishTitle
{
    public class GetBlogGroupByEnglishTitleQuery : IBaseRequest<BlogPostGroupDto>
    {
        public GetBlogGroupByEnglishTitleQuery(string englishTitle)
        {
            EnglishTitle = englishTitle.ToLower();
        }

        public string EnglishTitle { get; private set; }
    }
}