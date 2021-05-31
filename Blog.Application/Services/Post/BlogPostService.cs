using System;
using System.Threading.Tasks;
using Blog.Application.DTOs.Posts;
using Blog.Domain.Entities.BlogPostAggregate;
using Blog.Infrastructure.Context;
using framework;
using framework.Domain.Enums;
using framework.Services;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Post
{
    public class BlogPostService:BaseService,IBlogPostService
    {
        public BlogPostService(BlogContext context) : base(context)
        {
        }

        public async Task<BlogPostFilterDto> GetBlogPosts(int pageId, int take, string search, string categoryTitle, SearchOn searchOn, string postType)
        {
            return null;
            throw new System.NotImplementedException();
        }

        public async Task<bool> IsPostExist(long postId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> IsPostExist(string url)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResultModel<BlogPostDto>> GetPostBy(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResultModel<BlogPostDto>> GetPostBy(string url)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResultModel> InsertPost(InsertBlogPostDto model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResultModel> EditPost(EditBlogPostDto model)
        {
            throw new System.NotImplementedException();
        }
    }
}