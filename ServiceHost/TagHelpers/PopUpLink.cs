using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AdminPanel.TagHelpers
{
    [HtmlTargetElement("popupLink", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class PopUpLink : TagHelper
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string ModalTarget { get; set; } = "defaultModal";
        public string Size { get; set; } = "lg";
        public string Class { get; set; } = "btn btn-info";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.Add("class", Class);
            output.Attributes.Add("onclick", $"OpenModal('{Url}','{ModalTarget}','{Title}','{Size}',null)");
            base.Process(context, output);
        }
    }
}