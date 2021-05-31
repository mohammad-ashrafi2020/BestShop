using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Auth;
using Account.Application.Services.Users;
using framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;

namespace ServiceHost.Pages.Auth
{
    [ValidateAntiForgeryToken]
    public class ForgotPasswordModel : RazorBase
    {
        private IUserService _userService;

        public ForgotPasswordModel(IApplicationContext context, IUserService userService, ILogger<ForgotPasswordModel> logger) : base(context, logger)
        {
            _userService = userService;
        }
        [BindProperty]
        public ForgotPasswordDto PasswordDto { get; set; }

        public void OnGet()
        {
            if (_context.IsAuthenticated)
                Response.Redirect("/");
        }

        public async Task<IActionResult> OnPost()
        {
            return await TryCatch(async () =>
            {
                var res = await _userService.ForgotPassword(PasswordDto);
                if (res.Status == ResultModelStatus.NotFound)
                    res.Message = "کاربری با ایمیل وارد شده یافت نشد";
                return res;
            },successReturn:"/Auth/Login",successMessage:"لینک تغییر کلمه عبور به ایمیل شما ارسال شد");
        }
    }
}
