using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;
using System.Threading.Tasks;
using Blog.Application.Services.Posts.Queries.DTOs;

namespace ServiceHost.Areas.Admin.Pages.BlogManagement
{
    public class IndexModel : RazorBase
    {

        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger) : base(context, logger)
        {
        }


        public BlogPostFilterDto FilterDto { get; set; }
        public async Task OnGet(int pageId = 1, string search = "",
            string postType = "all", string searchOn = "", string category = "")
        {
            FilterDto = new BlogPostFilterDto();
        }



    }
}
