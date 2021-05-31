using System;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Account;
using Account.Application.Models.DTOs.Auth;
using Account.Application.Services.Users;
using Account.Configuration;
using framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;

namespace ServiceHost.Pages.Auth
{
    [ValidateAntiForgeryToken]
    public class RegisterModel : RazorBase
    {
        private IUserService _userService;

        public RegisterModel(IApplicationContext context, ILogger<RegisterModel> logger, IUserService userService) : base(context, logger)
        {
            _userService = userService;
        }
        [BindProperty]
        public RegisterDto RegisterDto { get; set; }
        public void OnGet()
        {
            if (_context.IsAuthenticated)
                Response.Redirect("/");

            RegisterDto = new RegisterDto();
        }

        public async Task<IActionResult> OnPost()
        {
            RegisterDto.RePassword = RegisterDto.Password;

            if (!ModelState.IsValid)
                return Page();


            return await TryCatch(async () =>
                await _userService.RegisterUser(RegisterDto),
                successTitle: "ثبت نام با موفقیت انجام شد",
                successReturn: "/auth/login");
        }
    }
}
