using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using AdminPanel.ViewModels.ShopManagement.Categories;
using Common.Application;
using Common.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Shop.Application.Categories.CategoryAttribute.Create;
using Shop.Application.Categories.CategoryAttribute.Edit;
using Shop.Application.Categories.CategoryAttribute.ToggleStatus;
using Shop.Query.Categories.Category.GetByFilter;
using Shop.Query.Categories.CategoryAttributes.GetByFilter;
using Shop.Query.Categories.CategoryAttributes.GetById;
using Shop.Query.DTOs.ProductCategories;

namespace AdminPanel.Pages.ShopManagement.Categories.Attributes
{
    [ValidateAntiForgeryToken]
    public class IndexModel : RazorBase
    {
        private readonly IRenderViewToString _renderView;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IMediator mediator, IRenderViewToString renderView) : base(context, logger, mediator)
        {
            _renderView = renderView;
        }

        public List<CategoryAttributeDto> Entities { get; set; }
        public List<SelectListItem> MainCategories { get; set; }
        public List<SelectListItem> SubCategories { get; set; }
        public int CategoryId { get; set; }
        public async Task OnGet(int categoryId = 0)
        {
            CategoryId = categoryId;
            var categories = await Mediator.Send(new GetCategoriesByFilterQuery(1, 500, null, null) { SearchOn = SearchOn.Active });
            var currentCategory = categories.Categories.FirstOrDefault(c => c.Id == categoryId);
            var main = categories.Categories.Where(c => c.ParentId == null);

            MainCategories = main.Select(s => new SelectListItem()
            {
                Text = s.CategoryTitle,
                Value = s.Id.ToString(),
                Selected = currentCategory?.ParentId == s.Id
            }).ToList();

            if (currentCategory != null)
            {
                if (currentCategory.ParentId == null)
                {
                    CategoryId = 0;
                    return;
                }

                var sub = categories.Categories.Where(c => c.ParentId == currentCategory.ParentId);
                SubCategories = sub.Select(s => new SelectListItem()
                {
                    Text = s.CategoryTitle,
                    Value = s.Id.ToString(),
                    Selected = categoryId == s.Id
                }).ToList();

                Entities = await Mediator.Send(new GetCategoryAttributeByFilter(categoryId));
            }
        }

        public async Task<IActionResult> OnGetToggleStatus(long id)
        {
            return await AjaxTryCatch(async () =>
               await Mediator.Send(new ToggleCategoryAttributeStatusCommand(id)), true);
        }
        #region Insert

        public async Task<IActionResult> OnPostInsert(AddProductCategoryAttributeViewModel model)
        {
            return await AjaxTryCatch(async ()
                    => await Mediator.Send(new CreateCategoryAttributeCommand
                        (model.Key, model.Hint, model.DisplayOrder, model.CategoryId, model.ShowInLandingPage, model.ParentId))
                , true);
        }
        public async Task<IActionResult> OnGetShowInsertPage(int categoryId, long parentId)
        {
            return await AjaxTryCatch(async () =>
            {
                var view = await _renderView.RenderToStringAsync("_Add", new AddProductCategoryAttributeViewModel()
                {
                    CategoryId = categoryId,
                    ParentId = parentId
                }, PageContext);
                return OperationResult<string>.Success(data: view);
            });
        }

        #endregion

        #region Edit

        public async Task<IActionResult> OnPostEdit(EditProductCategoryAttributeViewModel model)
        {
            return await AjaxTryCatch(async ()
                    => await Mediator.Send(new EditCategoryAttributeCommand
                        (model.Id, model.Key, model.Hint, model.DisplayOrder))
                , true);
        }
        public async Task<IActionResult> OnGetShowEditPage(long id)
        {
            return await AjaxTryCatch(async () =>
            {
                var model = await Mediator.Send(new GetCategoryAttributeById(id));
                if (model == null)
                    return OperationResult<string>.NotFound();

                var view = await _renderView.RenderToStringAsync("_Edit", new EditProductCategoryAttributeViewModel()
                {
                    CategoryId = model.CategoryId,
                    DisplayOrder = model.DisplayOrder,
                    Hint = model.Hint,
                    Id = model.Id,
                    Key = model.Key,
                    ParentId = model.ParentId,
                    ShowInLandingPage = model.ShowInLandingPage
                }, PageContext);
                return OperationResult<string>.Success(data: view);
            });
        }

        #endregion
    }
}
