using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Account;
using Account.Application.Models.DTOs.Auth;
using Account.Application.Services.Users;
using Account.Application.Services.Users.Wallets;
using Account.Configuration;
using framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.Cookies;
using ServiceHost.Infrastructure.DTOs;
using ServiceHost.Infrastructure.RazorUtils;
namespace ServiceHost.Pages.Auth
{
    public class LoginModel : RazorBase
    {
        private IUserService _userService;
        private IConfiguration _configuration;
        private IUserWalletService _walletService;

        public LoginModel(IApplicationContext context, ILogger<LoginModel> logger, IUserService userService, IConfiguration configuration, IUserWalletService walletService) : base(context, logger)
        {
            _userService = userService;
            _configuration = configuration;
            _walletService = walletService;
        }

        [BindProperty]
        public LoginDto LoginDto { get; set; }
        public void OnGet(string returnUrl)
        {
            if (_context.IsAuthenticated)
                Response.Redirect("/");
        }

        public async Task<IActionResult> OnPost(bool reMemberMe)
        {

            return await TryCatch(async () =>
            {
                var user = await _userService.LoginUser(LoginDto);
                if (user.Status != ResultModelStatus.Success)
                {
                    if (user.Status == ResultModelStatus.NotFound)
                        user.Message = "کاربری با مشخصات وارد شده یافت شد";
                    return user;
                }

                var token = GenerateJwtToken.Generate(user.Data, _configuration);
                await SetCookies(user.Data, token, reMemberMe);
                return user;
            }, successReturn: "/");
        }

        #region Utils

        private async Task SetCookies(UserDto userDto, string token, bool reMemberMe)
        {

            HttpContext.Response.Cookies.Append("BestShopCookie", token, new CookieOptions()
            {
                Expires = reMemberMe ? DateTimeOffset.Now.AddDays(30) :
                DateTimeOffset.Now.AddDays(1)
            });
            CookieUtils.SetUserInfoCookie(userDto, HttpContext, await _walletService.BalanceWallet(userDto.Id));
        }

        #endregion
    }
}
