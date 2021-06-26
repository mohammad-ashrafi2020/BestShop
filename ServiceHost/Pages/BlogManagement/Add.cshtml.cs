using System;
using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using AdminPanel.ViewModels.Posts;
using Blog.Application.Services.Posts.Commands.CreatePost;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminPanel.Pages.BlogManagement
{
    [ValidateAntiForgeryToken]
    public class AddModel : RazorBase
    {
        public AddModel(IApplicationContext context, ILogger<AddModel> logger, IMediator mediator) : base(context, logger, mediator)
        {
        }

        [BindProperty]
        public InsertBlogPostViewModel InsertModel { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var userId = Guid.NewGuid();//Fake UserId
            return await TryCatch(async () => await Mediator.Send(new CreatePostCommand(
                    userId,
                    InsertModel.Title,
                    InsertModel.UrlTitle,
                    InsertModel.MetaDescription,
                    InsertModel.Description, InsertModel.ImageAlt, InsertModel.Tags, InsertModel.TimeRequiredToStudy,
                    InsertModel.GroupId, InsertModel.SubGroupId, InsertModel.DateRelease,
                    InsertModel.IsSpecial, InsertModel.IsActive, InsertModel.ImageFile))
                , "/blogManagement");
        }


    }
}
