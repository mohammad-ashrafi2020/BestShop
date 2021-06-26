using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using AdminPanel.ViewModels.Posts;
using Blog.Application.Services.Posts.Commands.EditPost;
using Blog.Application.Services.Posts.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminPanel.Pages.BlogManagement
{
    public class EditModel : RazorBase
    {
        public EditModel(IApplicationContext context, ILogger logger, IMediator mediator) : base(context, logger, mediator)
        {
        }

        [BindProperty]
        public EditBlogPostViewModel Edit { get; set; }
        public async Task<IActionResult> OnGet(long id)
        {
            var model = await Mediator.Send(new GetPostByIdQuery(id));
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
            return await TryCatch(async () => await Mediator.Send(new
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
