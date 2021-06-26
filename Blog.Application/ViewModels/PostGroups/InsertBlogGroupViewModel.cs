using System.ComponentModel.DataAnnotations;
using Common.Application.Validation;

namespace Blog.Application.ViewModels.PostGroups
{
    public class InsertBlogGroupViewModel
    {
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MaxLength(400,ErrorMessage = ValidationMessages.MaxLength)]
        public string GroupTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(400, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string EnglishGroupTitle { get; set; }


        [Display(Name = "MetaDescription")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        public string MetaDescription { get; set; }

        public long? ParentId { get; set; }
    }
}