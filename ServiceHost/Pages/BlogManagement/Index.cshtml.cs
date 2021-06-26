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
        private readonly IMediator _mediator;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IMediator mediator) : base(context, logger)
        {
            _mediator = mediator;
        }

        public BlogPostFilterDto FilterDto { get; set; }
        public async Task OnGet(int pageId = 1, string search = "",
            SearchOn searchOn = SearchOn.All, string category = "")
        {
            FilterDto = await _mediator.Send(new GetAllPostByFilterQuery(searchOn, category, search, 20, pageId));
        }

        public async Task<IActionResult> OnGetToggleStatus(long id)
        {
            return await AjaxTryCatch(async () =>
                await _mediator.Send(new TogglePostStatusCommand(id)), true);
        }
    }
}

