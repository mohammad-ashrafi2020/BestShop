using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Addresses;
using Account.Domain.Entities.Users;
using AutoMapper;
using framework;
using framework.UserUtil;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;

namespace ServiceHost.Pages.Profile.Addresses
{
    [ValidateAntiForgeryToken]
    public class IndexModel : RazorBase
    {
        private IRenderViewToString _renderView;
        private IMapper _mapper;

        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IRenderViewToString renderView, IMapper mapper) : base(context, logger)
        {
            _renderView = renderView;
            _mapper = mapper;
        }


        public List<UserAddress> UserAddresses { get; set; }

        #region Methods

        public async Task OnGet()
        {
            //var res = await _address.GetUserAddresses(User.GetUserId());
            //UserAddresses = res.Data;
        }

        public async Task<IActionResult> OnPostInsertAddress(InsertAddressDto insertAddress)
        {
            insertAddress.UserId = User.GetUserId();
            return await AjaxTryCatch(async () =>
            {
               // var res = await _address.InsertAddress(insertAddress);
                return ResultModel.Success();
            }, isSuccessReloadPage: true);
        }
        public async Task<IActionResult> OnPostEditAddress(EditAddressDto addressDto)
        {
            addressDto.UserId = User.GetUserId();
            return await AjaxTryCatch(async () =>
            {
                //var address = await _address.AddressIsExistBy(addressDto.Id, User.GetUserId());
                //if (!address)
                //    return ResultModel.NotFound("اطلاعات ارسالی نامعتبر است");
                //var res = await _address.EditAddress(addressDto);
                return ResultModel.Success();
            }, isSuccessReloadPage: true);
        }
        #endregion

        #region GetMethods_Handlers
        public async Task<IActionResult> OnGetShowInsertPartial()
        {
            var view = await _renderView.RenderToStringAsync("_Add", new InsertAddressDto(), PageContext);
            return await AjaxTryCatch(async () =>
            {
                var res = new ResultModel<string>()
                {
                    Status = ResultModelStatus.Success,
                    Title = null,
                    Message = null,
                    Data = view
                };
                return res;
            });
        }
        public async Task<IActionResult> OnGetShowEditPartial(long addressId)
        {
            return await AjaxTryCatch(async () =>
             {
                 //var address = await _address.GetAddressById(addressId);
                 //if (address.Status != ResultModelStatus.Success)
                 //    return ResultModel<string>.Error("اطلاعات نامعتبر است");
                 //var model = _mapper.Map<EditAddressDto>(address.Data);
                 //var view = await _renderView.RenderToStringAsync("_Edit", model, PageContext);

                 var res = new ResultModel<string>()
                 {
                     Status = ResultModelStatus.Success,
                     Title = null,
                     Message = null,
                     Data = "view"
                 };
                 return res;
             });
        }
        public async Task<IActionResult> OnGetActiveAddress(long addressId)
        {
            return await AjaxTryCatch(async () =>
            {
                //var res = await _address.SetDefaultAddress(User.GetUserId(), addressId);
                return ResultModel.Success();
            });
        }
        public async Task<IActionResult> OnGetDeleteAddress(long addressId)
        {
            return await AjaxTryCatch(async () =>
            {
               // var res = await _address.DeleteAddress(User.GetUserId(), addressId);
                return ResultModel.Success();
            });
        }

        #endregion
    }
}