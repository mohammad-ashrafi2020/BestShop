using framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Application.Services.PostGroups.Commands.CreateGroup;
using Blog.Application.Services.PostGroups.Commands.EditGroup;
using Blog.Application.Services.PostGroups.Commands.TogglePostGroupStatus;
using Blog.Application.Services.PostGroups.Queries.DTOs;
using Blog.Application.Services.PostGroups.Queries.GetAll;
using Blog.Application.Services.PostGroups.Queries.GetById;
using Blog.Application.ViewModels.PostGroups;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using MediatR;

namespace ServiceHost.Areas.Admin.Pages.BlogManagement.Groups
{
    [ValidateAntiForgeryToken]
    public class IndexModel : RazorBase
    {
        private IRenderViewToString _renderView;
        private IMediator _mediator;

        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger
           , IRenderViewToString renderView, IMediator mediator) : base(context, logger)
        {
            _renderView = renderView;
            _mediator = mediator;
        }

        public List<BlogPostGroupDto> Groups { get; set; }
        public async Task OnGet()
        {
            Groups = await _mediator.Send(new GetAllPostGroupQuery());
        }

        #region PostHandlers
        public async Task<IActionResult> OnPostInsertGroup(InsertBlogGroupViewModel model)
        {
            return await AjaxTryCatch(async () =>
            {
                return await _mediator.Send(new CreateGroupCommand(model.GroupTitle, model.EnglishGroupTitle,
                    model.MetaDescription, model.ParentId));
            }, isSuccessReloadPage: true);
        }
        public async Task<IActionResult> OnPostEditGroup(EditBlogGroupViewModel model)
        {
            return await AjaxTryCatch(async () =>
                await _mediator.Send(new EditPostGroupCommand(model.Id, model.ParentId, model.MetaDescription, model.EnglishGroupTitle, model.GroupTitle)), isSuccessReloadPage: true);
        }

        #endregion

        #region GetHandlers

        public async Task<IActionResult> OnGetToggleStatus(long id)
        {
            return await AjaxTryCatch(async () =>
                await _mediator.Send(new TogglePostGroupStatusCommand(id)),true);
        }
        public async Task<IActionResult> OnGetShowInsertModal(long? parent)
        {
            var model = new InsertBlogGroupViewModel()
            {
                EnglishGroupTitle = null,
                MetaDescription = null,
                ParentId = parent,
                GroupTitle = null
            };
            return await AjaxTryCatch(async () =>
            {
                var result = new OperationResult<string>()
                {
                    Data = await _renderView.RenderToStringAsync("_Add", model, PageContext),
                    Status = OperationResultStatus.Success,
                    Title = "",
                    Message = ""
                };

                return result;
            });
        }
        public async Task<IActionResult> OnGetShowEditModal(long id)
        {
            return await AjaxTryCatch<string>(async () =>
            {

                var group = await _mediator.Send(new GetPostGroupByIdQuery(id));
                if (group == null)
                    return OperationResult<string>.NotFound();

                var model = new EditBlogGroupViewModel()
                {
                    EnglishGroupTitle = group.EnglishGroupTitle,
                    GroupTitle = group.GroupTitle,
                    Id = group.Id,
                    ParentId = group.ParentId,
                    MetaDescription = group.MetaDescription
                };
                var result = new OperationResult<string>()
                {
                    Data = await _renderView.RenderToStringAsync("_Edit", model, PageContext),
                    Status = OperationResultStatus.Success,
                    Title = "",
                    Message = ""
                };

                return result;
            });
        }
        #endregion
    }
}
