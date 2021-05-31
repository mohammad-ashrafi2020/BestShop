using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application.DTOs.Groups;
using Blog.Application.Services.Groups;
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
        private IBlogGroupService _groupService;
        private IRenderViewToString _renderView;
        private IMapper _mapper;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger,
            IBlogGroupService groupService, IMapper mapper, IRenderViewToString renderView) : base(context, logger)
        {
            _groupService = groupService;
            _renderView = renderView;
            _mapper = mapper;
        }

        public List<BlogPostGroup> Groups { get; set; }
        public async Task OnGet()
        {
            Groups = await _groupService.GetGroupsForAdmin();
        }

        #region PostHandlers
        public async Task<IActionResult> OnPostInsertGroup(InsertBlogGroupDto model)
        {
            return await AjaxTryCatch(async () =>
            {
                var res = await _groupService.InsertGroup(model);
                return res;
            }, isSuccessReloadPage: true);
        }
        public async Task<IActionResult> OnPostEditGroup(EditBlogGroupDto model)
        {
            return await AjaxTryCatch(async () =>
            {
                var res = await _groupService.EditGroup(model);
                return res;
            }, isSuccessReloadPage: true);
        }

        #endregion

        #region GetHandlers

        public async Task<IActionResult> OnGetDeleteGroup(long id)
        {
            return await AjaxTryCatch(async () =>
            {
                return await _groupService.DeleteGroup(id);
            },isSuccessReloadPage:true);
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
                var group = await _groupService.GetGroupBy(id);
                if (group.Data == null)
                    return ResultModel<string>.NotFound();

                var model = _mapper.Map<EditBlogGroupDto>(group.Data);
                var result = new ResultModel<string>()
                {
                    Data = await _renderView.RenderToStringAsync("_Edit", model, PageContext),
                    Status = ResultModelStatus.Success,
                    Title = "",
                    Message = ""
                };

                return result;
            });
        }
        #endregion
    }
}
