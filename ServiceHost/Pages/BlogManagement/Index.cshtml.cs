using System;
using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using Blog.Application.Services.Posts.Commands.ToggleStatus;
using Blog.Application.Services.Posts.Queries.DTOs;
using Blog.Application.Services.Posts.Queries.GetAllByFilter;
using Common.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminPanel.Pages.BlogManagement
{
    public class IndexModel : RazorBase
    {
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IMediator mediator) : base(context, logger, mediator)
        {
        }

        public BlogPostFilterDto FilterDto { get; set; }
        public async Task OnGet(int pageId = 1, string search = "",
            SearchOn searchOn = SearchOn.All, string category = "")
        {
            FilterDto = await Mediator.Send(new GetAllPostByFilterQuery(searchOn, category, search, 20, pageId));
        }

        public async Task<IActionResult> OnGetToggleStatus(long id)
        {
            return await AjaxTryCatch(async () =>
                await Mediator.Send(new TogglePostStatusCommand(id)), true);
        }
    }
}

