using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using AdminPanel.ViewModels.ShopManagement.Categories;
using Common.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Application.ProductCategories.ProductCategory.Create;
using Shop.Application.ProductCategories.ProductCategory.Edit;
using Shop.Application.ProductCategories.ProductCategory.ToggleStatus;
using Shop.Domain.ValueObjects;
using Shop.Query.DTOs.ProductCategories.Filters;
using Shop.Query.ProductCategories.ProductCategory.GetByFilter;
using Shop.Query.ProductCategories.ProductCategory.GetById;

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

        public ProductCategoriesFilterDto FilterDto { get; set; }

        public async Task OnGet(int pageId = 1, string title = null)
        {
            FilterDto = await Mediator.Send(new GetProductCategoriesByFilterQuery(pageId, 15, title));
        }

        #region PostHandlers

        public async Task<IActionResult> OnGetToggleStatus(int id)
        {
            return await AjaxTryCatch(async () =>
                await Mediator.Send(new ProductCategoryToggleStatusCommand(id)), true);
        }
        public async Task<IActionResult> OnPostAddCategory(AddShopCategoryViewModel model)
        {
            return await AjaxTryCatch(async () =>
            {
                var command = new CreateProductCategoryCommand(
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
                var command = new EditProductCategoryCommand(
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
                    MetaKeyWords = model.MetaValue.KeyWords?.Replace(",","-"),
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
    }
}
