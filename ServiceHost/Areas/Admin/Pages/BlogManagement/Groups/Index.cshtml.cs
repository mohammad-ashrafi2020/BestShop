using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application.DTOs.Groups;
using Blog.Domain.Entities;
using framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;

namespace ServiceHost.Areas.Admin.Pages.BlogManagement.Groups
{
    [ValidateAntiForgeryToken]
    public class IndexModel : RazorBase
    {
        private IRenderViewToString _renderView;
        private IMapper _mapper;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger,
            IMapper mapper, IRenderViewToString renderView) : base(context, logger)
        {
            _renderView = renderView;
            _mapper = mapper;
        }

        public List<BlogPostGroup> Groups { get; set; }
        public async Task OnGet()
        {
            Groups = new List<BlogPostGroup>();
        }

        #region PostHandlers
        public async Task<IActionResult> OnPostInsertGroup(InsertBlogGroupDto model)
        {
            return await AjaxTryCatch(async () =>
            {
                return ResultModel.NotFound();
                //var res = await _groupService.InsertGroup(model);
                //return res;
            }, isSuccessReloadPage: true);
        }
        public async Task<IActionResult> OnPostEditGroup(EditBlogGroupDto model)
        {
            return await AjaxTryCatch(async () =>
            {
                return ResultModel.NotFound();
                //var res = await _groupService.EditGroup(model);
                //return res;
            }, isSuccessReloadPage: true);
        }

        #endregion

        #region GetHandlers

        public async Task<IActionResult> OnGetDeleteGroup(long id)
        {
            return NotFound();
        }
        public async Task<IActionResult> OnGetShowInsertModal(long? parent)
        {
            var model = new InsertBlogGroupDto()
            {
                EnglishGroupTitle = null,
                MetaDescription = null,
                ParentId = parent,
                GroupTitle = null
            };
            return await AjaxTryCatch(async () =>
            {
                var result = new ResultModel<string>()
                {
                    Data = await _renderView.RenderToStringAsync("_Add", model, PageContext),
                    Status = ResultModelStatus.Success,
                    Title = "",
                    Message = ""
                };

                return result;
            });
        }
        public async Task<IActionResult> OnGetShowEditModal(long id)
        {
            return await AjaxTryCatch(async () =>
            {
                return ResultModel<string>.NotFound();

                //var group = await _groupService.GetGroupBy(id);
                //if (group.Data == null)

                //var model = _mapper.Map<EditBlogGroupDto>(group.Data);
                //var result = new ResultModel<string>()
                //{
                //    Data = await _renderView.RenderToStringAsync("_Edit", model, PageContext),
                //    Status = ResultModelStatus.Success,
                //    Title = "",
                //    Message = ""
                //};

                //return result;
            });
        }
        #endregion
    }
}
