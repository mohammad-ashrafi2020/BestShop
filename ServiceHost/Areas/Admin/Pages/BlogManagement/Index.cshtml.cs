using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;
using System.Threading.Tasks;
using Blog.Application.Services.Posts.Queries.DTOs;
using Blog.Application.Services.Posts.Queries.GetAllByFilter;
using framework.Enums;
using MediatR;

namespace ServiceHost.Areas.Admin.Pages.BlogManagement
{
    public class IndexModel : RazorBase
    {
        private IMediator _mediator;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IMediator mediator) : base(context, logger)
        {
            _mediator = mediator;
        }

        public BlogPostFilterDto FilterDto { get; set; }
        public async Task OnGet(int pageId = 1, string search = "",
            SearchOn searchOn = SearchOn.All, string category = "")
        {
            FilterDto = await _mediator.Send(new GetAllPostByFilterQuery(searchOn, category, search, 10, pageId));
        }

    }
}
