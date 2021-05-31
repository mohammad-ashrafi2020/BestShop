using System.Threading.Tasks;
using Blog.Application.DTOs.Posts;
using framework;
using framework.Domain.Enums;

namespace Blog.Application.Services.Post
{
    public interface IBlogPostService
    {
        Task<BlogPostFilterDto> GetBlogPosts(int pageId, int take, string search
            , string categoryTitle, SearchOn searchOn, string postType);

        Task<bool> IsPostExist(long postId);
        Task<bool> IsPostExist(string url);
        Task<ResultModel<BlogPostDto>> GetPostBy(long id);
        Task<ResultModel<BlogPostDto>> GetPostBy(string url);
        Task<ResultModel> InsertPost(InsertBlogPostDto model);
        Task<ResultModel> EditPost(EditBlogPostDto model);
    }
}