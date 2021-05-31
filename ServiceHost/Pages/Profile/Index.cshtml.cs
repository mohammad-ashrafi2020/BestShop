using System.Threading.Tasks;
using Account.Application.Models.DTOs.Account;
using Account.Application.Services.Users;
using framework;
using framework.UserUtil;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;

namespace ServiceHost.Pages.Profile
{
    public class IndexModel : RazorBase
    {
        private IUserService _userService;
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger, IUserService userService) : base(context, logger)
        {
            _userService = userService;
        }

        public UserDto UserModel { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var res = await _userService.GetUserBy(User.GetUserId());
            if (res.Status != ResultModelStatus.Success)
                return Redirect("/");

            UserModel = res.Data;
            return Page();
        }
    }
}
