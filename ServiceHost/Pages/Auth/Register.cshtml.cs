using Account.Application.Models.DTOs.Auth;
using framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;
using System;
using System.Threading.Tasks;

namespace ServiceHost.Pages.Auth
{
    [ValidateAntiForgeryToken]
    public class RegisterModel : RazorBase
    {

        public RegisterModel(IApplicationContext context, ILogger<RegisterModel> logger) : base(context, logger)
        {
        }
        [BindProperty]
        public RegisterDto RegisterDto { get; set; }
        public void OnGet()
        {
            if (Context.IsAuthenticated)
                Response.Redirect("/");

            RegisterDto = new RegisterDto();
        }

        public async Task<IActionResult> OnPost()
        {
            RegisterDto.RePassword = RegisterDto.Password;

            if (!ModelState.IsValid)
                return Page();


            return await TryCatch(async () =>
                    OperationResult.Success(),
                successTitle: "ثبت نام با موفقیت انجام شد",
                successReturn: "/auth/login");
        }
    }
}
