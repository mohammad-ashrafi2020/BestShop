using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceHost.TagHelpers
{
    [HtmlTargetElement("description", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class LabelDescription : TagHelper
    {
        public string Text { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "small";
            output.Content.SetContent($"( {Text} )");
            base.Process(context, output);
        }
    }
}