using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Application.DTOs.Posts;
using Blog.Application.Services.Groups;
using Blog.Application.Services.Post;
using Blog.Domain.Entities;
using framework.Domain.Enums;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;

namespace ServiceHost.Areas.Admin.Pages.BlogManagement
{
    public class IndexModel : RazorBase
    {
        private IBlogPostService _service;

        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IBlogPostService service) : base(context, logger)
        {
            _service = service;
        }


        public BlogPostFilterDto FilterDto { get; set; }
        public async Task OnGet(int pageId = 1, string search = "",
            string postType = "all", SearchOn searchOn = SearchOn.All, string category = "")
        {
            FilterDto = await _service.GetBlogPosts(pageId, 10, search, category, searchOn, postType);
        }



    }
}
