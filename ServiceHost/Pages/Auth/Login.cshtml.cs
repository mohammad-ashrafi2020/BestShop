using System;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Account;
using Account.Application.Models.DTOs.Auth;
using Account.Configuration;
using framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.Cookies;
using ServiceHost.Infrastructure.RazorUtils;
namespace ServiceHost.Pages.Auth
{
    public class LoginModel : RazorBase
    {
        private IConfiguration _configuration;

        public LoginModel(IApplicationContext context, ILogger<LoginModel> logger, IConfiguration configuration) : base(context, logger)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public LoginDto LoginDto { get; set; }
        public void OnGet(string returnUrl)
        {
            if (Context.IsAuthenticated)
                Response.Redirect("/");
        }

        //public async Task<IActionResult> OnPost(bool reMemberMe)
        //{

        //    return await TryCatch(async () =>
        //    {
        //        var user = await _userService.LoginUser(LoginDto);
        //        if (user.Status != OperationResultStatus.Success)
        //        {
        //            if (user.Status == OperationResultStatus.NotFound)
        //                user.Message = "کاربری با مشخصات وارد شده یافت شد";
        //            return user;
        //        }

        //        var token = GenerateJwtToken.Generate(user.Data, _configuration);
        //        await SetCookies(user.Data, token, reMemberMe);
        //        return user;
        //    }, successReturn: "/");
        //}

        #region Utils

        private async Task SetCookies(UserDto userDto, string token, bool reMemberMe)
        {

            HttpContext.Response.Cookies.Append("BestShopCookie", token, new CookieOptions()
            {
                Expires = reMemberMe ? DateTimeOffset.Now.AddDays(30) :
                DateTimeOffset.Now.AddDays(1)
            });
           // CookieUtils.SetUserInfoCookie(userDto, HttpContext, await _walletService.BalanceWallet(userDto.Id));
        }

        #endregion
    }
}
