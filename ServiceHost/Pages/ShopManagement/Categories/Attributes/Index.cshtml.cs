using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using AdminPanel.ViewModels.ShopManagement.Categories;
using Common.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Shop.Application.ProductCategories.ProductCategoryAttribute.Create;
using Shop.Application.ProductCategories.ProductCategoryAttribute.Edit;
using Shop.Application.ProductCategories.ProductCategoryAttribute.ToggleStatus;
using Shop.Query.DTOs.ProductCategories;
using Shop.Query.ProductCategories.ProductCategory.GetByFilter;
using Shop.Query.ProductCategories.ProductCategory.GetById;
using Shop.Query.ProductCategories.ProductCategoryAttributes.GetByFilter;
using Shop.Query.ProductCategories.ProductCategoryAttributes.GetById;

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

        public List<ProductCategoryAttributeDto> Entities { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
        public async Task OnGet(int categoryId = 0)
        {
            CategoryId = categoryId;
            var categories = await Mediator.Send(new GetProductCategoriesByFilterQuery(1, 500, null, null));
            Categories = categories.Categories.Select(s => new SelectListItem()
            {
                Text = s.CategoryTitle,
                Value = s.Id.ToString(),
                Selected = categoryId == s.Id
            }).ToList();
            Entities = await Mediator.Send(new GetProductCategoryAttributeByFilter(categoryId));
        }

        public async Task<IActionResult> OnGetToggleStatus(long id)
        {
            return await AjaxTryCatch(async () => 
               await Mediator.Send(new ToggleProductCategoryAttributeStatusCommand(id)), true);
        }
        #region Insert

        public async Task<IActionResult> OnPostInsert(AddProductCategoryAttributeViewModel model)
        {
            return await AjaxTryCatch(async ()
                    => await Mediator.Send(new CreateProductCategoryAttributeCommand
                        (model.Key, model.Hint, model.DisplayOrder, model.CategoryId,model.ParentId))
                , true);
        }
        public async Task<IActionResult> OnGetShowInsertPage(int categoryId,long parentId)
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
                    => await Mediator.Send(new EditProductCategoryAttributeCommand
                        (model.Id,model.Key, model.Hint, model.DisplayOrder))
                , true);
        }
        public async Task<IActionResult> OnGetShowEditPage(long id)
        {
            return await AjaxTryCatch(async () =>
            {
                var model =await Mediator.Send(new GetProductCategoryAttributeById(id));
                if(model==null)
                    return OperationResult<string>.NotFound();

                var view = await _renderView.RenderToStringAsync("_Edit", new EditProductCategoryAttributeViewModel()
                {
                    CategoryId = model.CategoryId,
                    DisplayOrder = model.DisplayOrder,
                    Hint = model.Hint,
                    Id = model.Id,
                    Key = model.Key,
                    ParentId = model.ParentId
                }, PageContext);
                return OperationResult<string>.Success(data: view);
            });
        }

        #endregion
    }
}
