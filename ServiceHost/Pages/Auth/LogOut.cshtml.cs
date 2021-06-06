using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Pages.Auth
{
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Response.Cookies.Delete("BestShopCookie");
            var redirectPath = Request.Headers["Referer"].ToString();
            if (redirectPath.ToLower().Contains("/userpanel") || string.IsNullOrEmpty(redirectPath))
            {
                redirectPath = "/";
            }
            HttpContext.Response.Cookies.Delete("userInfo");

            return Redirect(redirectPath);
        }
    }
}
