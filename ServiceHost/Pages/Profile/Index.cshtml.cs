using Account.Application.Models.DTOs.Account;
using framework;
using framework.UserUtil;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHost.Infrastructure;
using ServiceHost.Infrastructure.RazorUtils;
using System.Threading.Tasks;

namespace ServiceHost.Pages.Profile
{
    public class IndexModel : RazorBase
    {
        public IndexModel(IApplicationContext context, ILogger<IndexModel> logger) : base(context, logger)
        {
        }

        public UserDto UserModel { get; set; }
        public async Task<IActionResult> OnGet()
        {
            return Redirect("/");

            return Page();
        }
    }
}
