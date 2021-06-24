using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AdminPanel.TagHelpers
{
    [HtmlTargetElement("required", TagStructure = TagStructure.Unspecified)]
    public class RequiredLabel : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "small";
            output.Attributes.Add("class", "text-danger");
            output.Content.Append("*");
            base.Process(context, output);
        }
    }
}