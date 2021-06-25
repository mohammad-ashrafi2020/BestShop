using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using Blog.Application.Services.Posts.Commands.EditPost;
using Blog.Application.Services.Posts.Queries.GetById;
using Blog.Application.ViewModels.Posts;
using Common.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminPanel.Pages.BlogManagement
{
    public class EditModel : RazorBase
    {
        private readonly IMediator _mediator;

        public EditModel(IApplicationContext context, ILogger<EditModel> logger, IMediator mediator) : base(context, logger)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public EditBlogPostViewModel Edit { get; set; }
        public async Task<IActionResult> OnGet(long id)
        {
            var model = await _mediator.Send(new GetPostByIdQuery(id));
            if (model == null)
                return RedirectToPage("Index");

            Edit = new EditBlogPostViewModel()
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
            return Page();
        }
        public async Task<IActionResult> OnPost(long id)
        {
            return await TryCatch(async () => await _mediator.Send(new
                    EditPostCommand(
                        Edit.Title,
                        Edit.UrlTitle,
                        Edit.MetaDescription,
                        Edit.Description,
                        Edit.ImageAlt,
                        Edit.Tags,
                        Edit.TimeRequiredToStudy,
                        Edit.GroupId,
                        Edit.SubGroupId,
                        Edit.DateRelease,
                        Edit.IsSpecial,
                        Edit.IsActive,
                        Edit.ImageFile,
                        Edit.Id)),
                "/blogManagement");
        }

    }
}
