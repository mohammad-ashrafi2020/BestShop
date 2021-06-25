using System;
using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using Blog.Application.Services.Posts.Commands.CreatePost;
using Blog.Application.Services.Posts.Commands.EditPost;
using Blog.Application.Services.Posts.Commands.ToggleStatus;
using Blog.Application.Services.Posts.Queries.DTOs;
using Blog.Application.Services.Posts.Queries.GetAllByFilter;
using Blog.Application.Services.Posts.Queries.GetById;
using Blog.Application.ViewModels.Posts;
using Common.Application;
using Common.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminPanel.Pages.BlogManagement
{
    public class IndexModel : RazorBase
    {
        private readonly IMediator _mediator;
        private readonly IRenderViewToString _renderView;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IMediator mediator, IRenderViewToString renderView) : base(context, logger)
        {
            _mediator = mediator;
            _renderView = renderView;
        }

        public BlogPostFilterDto FilterDto { get; set; }
        public async Task OnGet(int pageId = 1, string search = "",
            SearchOn searchOn = SearchOn.All, string category = "")
        {
            FilterDto = await _mediator.Send(new GetAllPostByFilterQuery(searchOn, category, search, 1, pageId));
        }

        public async Task<IActionResult> OnGetToggleStatus(long id)
        {
            return await AjaxTryCatch(async () =>
                await _mediator.Send(new TogglePostStatusCommand(id)), true);
        }
    }
}

