﻿using Account.Application.Models.DTOs.Auth;
using framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Pages.Auth
{
    [ValidateAntiForgeryToken]
    public class ResetPasswordModel : RazorBase
    {

        public ResetPasswordModel(IApplicationContext context, ILogger<ResetPasswordModel> logger) : base(context, logger)
        {
        }
        [BindProperty]
        public ResetPasswordDto ResetPasswordDto { get; set; }
        public async Task<IActionResult> OnGet(string email, Guid activeCode)
        {
            //if (_context.IsAuthenticated)
            //    return Redirect("/");

            //var user = await _userService.GetUserByEmail(email);
            //if (user.Status != OperationResultStatus.Success)
            //    return Redirect("/");

            //if (user.Data.ActivationToken != activeCode)
            //    return Redirect("/");

            return Page();
        }

        public async Task<IActionResult> OnPost(string email, Guid activeCode)
        {
            ResetPasswordDto.ActivationToken = activeCode;
            ResetPasswordDto.Email = email;

            return await TryCatch(async () =>
                OperationResult.Success(),
                successReturn: "/Auth/Login",
                successMessage: "کلمه عبور با موفقیت تغییر کرد");
        }
    }
}
