using System.Threading.Tasks;
using AdminPanel.Infrastructure;
using AdminPanel.Infrastructure.RazorUtils;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AdminPanel.Pages.ShopManagement.Categories
{
    public class IndexModel : RazorBase
    {
        public IndexModel(IApplicationContext context, ILogger logger, IMediator mediator) : base(context, logger, mediator)
        {
        }
        public async Task OnGet()
        {

        }


    }
}
