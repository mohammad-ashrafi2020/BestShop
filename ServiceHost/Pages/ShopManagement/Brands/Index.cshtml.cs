using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using AdminPanel.ViewModels.ShopManagement.Brands;
using Common.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Application.Brands.Create;
using Shop.Application.Brands.Edit;
using Shop.Application.Brands.ToggleStatus;
using Shop.Query.Brands.BetById;
using Shop.Query.Brands.GetByFilter;
using Shop.Query.DTOs.Brands;

namespace AdminPanel.Pages.ShopManagement.Brands
{
    public class IndexModel : RazorBase
    {
        private readonly IRenderViewToString _renderView;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IMediator mediator, IRenderViewToString renderView) : base(context, logger, mediator)
        {
            _renderView = renderView;
        }

        public List<BrandDto> Brands { get; set; }
        public async Task OnGet()
        {
            Brands = await Mediator.Send(new GetBrandByFilter(null));
        }

        #region Insert
        public async Task<IActionResult> OnGetShowInsertPage()
        {
            return await AjaxTryCatch(async () =>
            {
                var view = await _renderView.RenderToStringAsync("_Add", new AddBrandViewModel(), PageContext);
                return OperationResult<string>.Success(data: view);
            });
        }
        public async Task<IActionResult> OnPostInsert(AddBrandViewModel model)
        {
            return await AjaxTryCatch(async () =>
            {
                var command = new CreateBrandCommand(model.Name, model.LogoFile, model.ImageFile);
                return await Mediator.Send(command);
            }, true);
        }
        #endregion
        #region Edit
        public async Task<IActionResult> OnGetShowEditPage(int id)
        {
            return await AjaxTryCatch(async () =>
            {
                var model =await Mediator.Send(new GetBrandById(id));
                var view = await _renderView.RenderToStringAsync("_Edit",
                    new EditBrandViewModel()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        ImageName = model.ImageName,
                        LogoName = model.LogoName
                    }, PageContext);
                return OperationResult<string>.Success(data: view);
            });
        }
        public async Task<IActionResult> OnPostEdit(EditBrandViewModel model)
        {
            return await AjaxTryCatch(async () =>
            {
                var command = new EditBrandCommand(model.Id, model.Name, model.LogoFile, model.ImageFile);
                return await Mediator.Send(command);
            }, true);
        }
        #endregion

        public async Task<IActionResult> OnGetToggleStatus(int id)
        {
            return await AjaxTryCatch(async () =>
                await Mediator.Send(new ToggleBrandStatusCommand(id)), true);
        }
    }
}
