using System;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;
using System.Threading.Tasks;
using Blog.Application.Services.Posts.Commands.CreatePost;
using Blog.Application.Services.Posts.Commands.EditPost;
using Blog.Application.Services.Posts.Commands.ToggleStatus;
using Blog.Application.Services.Posts.Queries.DTOs;
using Blog.Application.Services.Posts.Queries.GetAllByFilter;
using Blog.Application.Services.Posts.Queries.GetById;
using Blog.Application.ViewModels.Posts;
using framework;
using framework.DateUtil;
using framework.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.Pages.BlogManagement
{
    public class IndexModel : RazorBase
    {
        private IMediator _mediator;
        private IRenderViewToString _renderView;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IMediator mediator, IRenderViewToString renderView) : base(context, logger)
        {
            _mediator = mediator;
            _renderView = renderView;
        }

        public BlogPostFilterDto FilterDto { get; set; }
        public async Task OnGet(int pageId = 1, string search = "",
            SearchOn searchOn = SearchOn.All, string category = "")
        {
            FilterDto = await _mediator.Send(new GetAllPostByFilterQuery(searchOn, category, search, 10, pageId));
        }
        public async Task<IActionResult> OnPostEditPost(EditBlogPostViewModel post)
        {
            return await AjaxTryCatch(async () => await _mediator.Send(new
                    EditPostCommand(
                    post.Title,
                    post.UrlTitle,
                    post.MetaDescription,
                    post.Description, post.ImageAlt, post.Tags, post.TimeRequiredToStudy,
                    post.GroupId, post.SubGroupId, post.DateRelease, post.IsSpecial, post.IsActive,
                    post.ImageFile, post.Id)),
                true);
        }
        public async Task<IActionResult> OnPostInsertPost(InsertBlogPostViewModel post)
        {
            var userId = Guid.NewGuid();//Fake UserId
            return await AjaxTryCatch(async () => await _mediator.Send(new CreatePostCommand(
                userId,
                post.Title,
                post.UrlTitle,
                post.MetaDescription,
                post.Description, post.ImageAlt, post.Tags, post.TimeRequiredToStudy,
                post.GroupId, post.SubGroupId, post.DateRelease,
                post.IsSpecial, post.IsActive, post.ImageFile)),
                true);
        }
        public async Task<IActionResult> OnGetShowAddPage()
        {
            return await AjaxTryCatch(async ()
                => OperationResult<string>.Success(data: await _renderView.RenderToStringAsync("_Add", new InsertBlogPostViewModel(), PageContext)));
        }

        public async Task<IActionResult> OnGetShowEditPage(long id)
        {

            return await AjaxTryCatch(async () =>
            {
                var model = await _mediator.Send(new GetPostByIdQuery(id));
                if (model == null)
                    return OperationResult<string>.NotFound();

                var editModel = new EditBlogPostViewModel()
                {
                    AuthorId = model.AuthorId,
                    DateRelease = model.DateRelease.ToString(),
                    Description = model.Description,
                    GroupId = model.GroupId,
                    Id = model.Id,
                    MetaDescription = model.MetaDescription,
                    SubGroupId = model.SubGroupId,
                    Tags = model.Tags,
                    IsActive = model.IsActive,
                    ImageAlt = model.ImageAlt,
                    ImageName = model.ImageName,
                    IsSpecial = model.IsSpecial,
                    TimeRequiredToStudy = model.TimeRequiredToStudy,
                    Title = model.Title,
                    UrlTitle = model.Slug
                };
                return OperationResult<string>.Success(
                    data: await _renderView.RenderToStringAsync("_Edit",
                        editModel, PageContext));

            });
        }

        public async Task<IActionResult> OnGetToggleStatus(long id)
        {
            return await AjaxTryCatch(async () =>
                await _mediator.Send(new ToggleBlogPostStatusCommand(id)), true);
        }
    }
}

