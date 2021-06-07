using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceHost.TagHelpers
{
    [HtmlTargetElement("Question", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class QuestionButton : TagHelper
    {
        public string Url { get; set; }
        public string Class { get; set; } = "btn btn-sm btn-info";
        public string Description { get; set; } = null;
        public string Title { get; set; } = "آیا از انجام عملیات اطمینان دارید ؟";
        public string SuccessMessage { get; set; } = "عملیات با موفقیت انجام شد";
        public string CallBackFunction { get; set; } = null;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.Add("class", Class);
            output.Attributes.Add("onclick",$"Question('{Url}','{Title}','{Description}','{SuccessMessage}','{CallBackFunction}')");
        }
    }
}