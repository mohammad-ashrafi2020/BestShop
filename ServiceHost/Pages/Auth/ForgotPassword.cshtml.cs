using System.Threading.Tasks;
using Account.Application.Models.DTOs.Auth;
using framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;

namespace ServiceHost.Pages.Auth
{
    [ValidateAntiForgeryToken]
    public class ForgotPasswordModel : RazorBase
    {

        public ForgotPasswordModel(IApplicationContext context, ILogger<ForgotPasswordModel> logger) : base(context, logger)
        {
        }
        [BindProperty]
        public ForgotPasswordDto PasswordDto { get; set; }

        public void OnGet()
        {
            if (Context.IsAuthenticated)
                Response.Redirect("/");
        }

        public async Task<IActionResult> OnPost()
        {
            return await TryCatch(async () =>
            {
                //var res = await _userService.ForgotPassword(PasswordDto);
                //if (res.Status == OperationResultStatus.NotFound)
                //    res.Message = "کاربری با ایمیل وارد شده یافت نشد";
                return OperationResult.Success();
            },successReturn:"/Auth/Login",successMessage:"لینک تغییر کلمه عبور به ایمیل شما ارسال شد");
        }
    }
}
