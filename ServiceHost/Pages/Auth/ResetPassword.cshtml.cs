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
    public class ResetPasswordModel : RazorBase
    {
        private IUserService _userService;

        public ResetPasswordModel(IApplicationContext context, ILogger<ResetPasswordModel> logger, IUserService userService) : base(context, logger)
        {
            _userService = userService;
        }
        [BindProperty]
        public ResetPasswordDto ResetPasswordDto { get; set; }
        public async Task<IActionResult> OnGet(string email, Guid activeCode)
        {
            if (_context.IsAuthenticated)
                return Redirect("/");

            var user = await _userService.GetUserByEmail(email);
            if (user.Status != ResultModelStatus.Success)
                return Redirect("/");

            if (user.Data.ActivationToken != activeCode)
                return Redirect("/");

            return Page();
        }

        public async Task<IActionResult> OnPost(string email, Guid activeCode)
        {
            ResetPasswordDto.ActivationToken = activeCode;
            ResetPasswordDto.Email = email;

            return await TryCatch(async () =>
                await _userService.ResetPassword(ResetPasswordDto),
                successReturn: "/Auth/Login",
                successMessage: "کلمه عبور با موفقیت تغییر کرد");
        }
    }
}
