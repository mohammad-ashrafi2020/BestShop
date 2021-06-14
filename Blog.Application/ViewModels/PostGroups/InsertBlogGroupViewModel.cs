using System.ComponentModel.DataAnnotations;

namespace Blog.Application.ViewModels.PostGroups
{
    public class InsertBlogGroupViewModel
    {
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = framework.ValidationMessages.Required)]
        [MaxLength(400,ErrorMessage = framework.ValidationMessages.MaxLength)]
        public string GroupTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(400, ErrorMessage = framework.ValidationMessages.MaxLength)]
        [Required(ErrorMessage = framework.ValidationMessages.Required)]
        public string EnglishGroupTitle { get; set; }


        [Display(Name = "MetaDescription")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = framework.ValidationMessages.Required)]
        [MaxLength(500, ErrorMessage = framework.ValidationMessages.MaxLength)]
        public string MetaDescription { get; set; }

        public long? ParentId { get; set; }
    }
}