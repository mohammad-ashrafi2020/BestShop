using System.Collections.Generic;
using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using AdminPanel.ViewModels.ShopManagement.Categories;
using Common.Application;
using Common.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.ToggleStatus;
using Shop.Domain.ValueObjects;
using Shop.Query.Categories.Category.GetByFilter;
using Shop.Query.Categories.Category.GetById;
using Shop.Query.Categories.Category.GetByParentId;
using Shop.Query.DTOs.ProductCategories.Filters;

namespace AdminPanel.Pages.ShopManagement.Categories
{
    [ValidateAntiForgeryToken]
    public class IndexModel : RazorBase
    {
        private readonly IRenderViewToString _renderView;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IMediator mediator, IRenderViewToString renderView) : base(context, logger, mediator)
        {
            _renderView = renderView;
        }

        public CategoriesFilterDto FilterDto { get; set; }

        public async Task OnGet(int pageId = 1, string title = null)
        {
            FilterDto = await Mediator.Send(new GetCategoriesByFilterQuery(pageId, 15, title));
        }

        #region PostHandlers

        public async Task<IActionResult> OnGetToggleStatus(int id)
        {
            return await AjaxTryCatch(async () =>
                await Mediator.Send(new ToggleCategoryStatusCommand(id)), true);
        }
        public async Task<IActionResult> OnPostAddCategory(AddShopCategoryViewModel model)
        {
            return await AjaxTryCatch(async () =>
            {
                var command = new CreateCategoryCommand(
                    model.Slug, model.Title
                    , new MetaValue(model.MetaTitle, model.MetaDescription, model.MetaKeyWords)
                    , model.ShowInMenu,
                    model.ParentId,
                    model.ImageFile);
                var res = await Mediator.Send(command);
                return res;
            }, true);
        }
        public async Task<IActionResult> OnPostEditCategory(EditShopCategoryViewModel model)
        {
            return await AjaxTryCatch(async () =>
            {
                var command = new EditCategoryCommand(
                    model.Id, model.Slug, model.Title
                    , new MetaValue(model.MetaTitle, model.MetaDescription, model.MetaKeyWords)
                    , model.ShowInMenu, model.ImageFile);
                var res = await Mediator.Send(command);
                return res;
            }, true);
        }
        #endregion

        #region GetHandlers

        public async Task<IActionResult> OnGetShowAddPage(int parentId)
        {
            return await AjaxTryCatch(async () =>
            {
                var view = await _renderView.RenderToStringAsync("_Add", new AddShopCategoryViewModel() { ParentId = parentId }, PageContext);
                return OperationResult<string>.Success(data: view);
            });
        }
        public async Task<IActionResult> OnGetShowEditPage(int id)
        {
            return await AjaxTryCatch(async () =>
            {
                var model = await Mediator.Send(new GetProductCategoryById(id));
                var viewModel = new EditShopCategoryViewModel()
                {
                    Id = id,
                    ParentId = model.ParentId,
                    MetaDescription = model.MetaValue.Description,
                    MetaKeyWords = model.MetaValue.KeyWords?.Replace(",", "-"),
                    MetaTitle = model.MetaValue.Title,
                    ShowInMenu = model.ShowInMenu,
                    Slug = model.Slug,
                    Title = model.CategoryTitle,
                    ImageName = model.ImageName
                };
                var view = await _renderView.RenderToStringAsync("_Edit", viewModel, PageContext);
                return OperationResult<string>.Success(data: view);
            });
        }
        #endregion

        public async Task<JsonResult> OnGetLoadChildCategories(int parentId)
        {
            var group = await Mediator.Send(new GetCategoriesByParentId(parentId) { SearchOn = SearchOn.Active });
            List<ObjectResult> values = new List<ObjectResult>();

            foreach (var item in group)
            {
                values.Add(new ObjectResult(new { value = item.Id, title = item.CategoryTitle }));
            }

            return new JsonResult(values);
        }
    }
}
