using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace ServiceHost.TagHelpers
{
    [HtmlTargetElement("popupLink", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class PopUpLink : TagHelper
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string ModalTarget { get; set; } = "defaultModal";
        public string Size { get; set; } = "lg";
        public string Class { get; set; } = "btn btn-info";
        public string Text { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Content.Append(Text);
            output.Attributes.Add("class", Class);
            output.Attributes.Add("onclick", $"OpenModal('{Url}','{ModalTarget}','{Title}','{Size}',null)");
            base.Process(context, output);
        }
    }
}