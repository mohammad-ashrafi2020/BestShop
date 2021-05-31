using System;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Account;
using framework;
using framework.UserUtil;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.Cookies;
using ServiceHost.Infrastructure.RazorUtils;

namespace ServiceHost.Pages.Profile
{
    public class EditModel : RazorBase
    {
        private IApplicationContext _appContext;

        public EditModel(IApplicationContext context, ILogger<EditModel> logger, IApplicationContext appContext) : base(context, logger)
        {
            _appContext = appContext;
        }

        [BindProperty]
        public EditUserDto EditUserDto { get; set; }
        [BindProperty]
        public DateTime? BirthDate { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var res = await GenerateDefaultValues();
            if (!res)
                return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            EditUserDto.UserId = User.GetUserId();

            return await TryCatch(async () =>
            {
                //var res = await _userService.EditUser(EditUserDto);
                //if (res.Status == ResultModelStatus.Success)
                //{
                //    var userInfo = _appContext.GetUserInfo();
                //    userInfo.FullName = $"{EditUserDto.Name} {EditUserDto.Family}";
                //    userInfo.Email = EditUserDto.Email;
                //    userInfo.ImageName = res.Data.ImageName;
                //    CookieUtils.SetUserInfoCookie(userInfo, HttpContext);
                //}
                return ResultModel.Success();
            }, successReturn: "/Profile");
        }

        #region Utils

        private async Task<bool> GenerateDefaultValues()
        {
            //var user = await _userService.GetUserBy(User.GetUserId());
            //if (user.Status != ResultModelStatus.Success) return false;
            //BirthDate = user.Data.BirthDate;
            //EditUserDto = new EditUserDto()
            //{
            //    Name = user.Data.Name,
            //    Family = user.Data.Family,
            //    Email = user.Data.Email,
            //    NationalCode = user.Data.NationalCode,
            //    Gender = user.Data.Gender,
            //    UserId = user.Data.Id,
            //    BirthDate = user.Data.BirthDate == null ? null : user.Data.BirthDate.ToPersianDate(),
            //    IsActive = user.Data.IsActive
            //};
            return true;
        }

        #endregion
    }
}
