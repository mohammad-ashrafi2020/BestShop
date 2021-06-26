using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("cancel",TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CancelButton : TagHelper
    {
        public string BackUrl { get; set; } = "/";
        public string Text { get; set; } = "انصراف";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href",BackUrl);
            output.Attributes.Add("class", "btn btn-danger waves-effect");
            output.Content.SetContent(Text);
        }
    }
}
