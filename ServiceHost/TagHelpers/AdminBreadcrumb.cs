using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;

namespace ServiceHost.TagHelpers
{
    [HtmlTargetElement("breadcrumb", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class AdminBreadcrumb : TagHelper
    {
        private IHttpContextAccessor _accessor;
        public AdminBreadcrumb(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            output.AddClass("content-header", HtmlEncoder.Default);
            output.Content.AppendHtml($"<h1>{ViewContext.ViewData["title"] ?? ""}</h1>");
            var href = _accessor.HttpContext.Request.Path.ToString();
            var host = $"{_accessor.HttpContext.Request.Scheme}://{_accessor.HttpContext.Request.Host}";
            var splited = href.Split("/").ToList();
            splited.RemoveAt(0);
            var htmlBody = "<ol class='breadcrumb'>";
            var index = -1;
            foreach (var section in splited)
            {
                //^1 = splited.count - 1
                if (section == splited[^1])
                    htmlBody += $"<li class='active'><a>{section}</a></li>";
                else
                {
                    if (index == 0)
                        htmlBody += $"<li><a href='{host}/{splited[index]}/{section}'>{section}</a></li>";
                    else if (index == 1)
                        htmlBody += $"<li><a href='{host}/{splited[0]}/{splited[index]}/{section}'>{section}</a></li>";
                    else if (index == 2)
                        htmlBody += $"<li><a href='{host}/{splited[0]}/{splited[2]}/{splited[index]}/{section}'>{section}</a></li>";
                    else
                        htmlBody += $"<li><a href='{host}/{section}'>{section}</a></li>";
                }

                index += 1;
            }
            htmlBody += "</ol>";
            output.PreContent.AppendHtml(htmlBody);
            base.Process(context, output);
        }
    }
}