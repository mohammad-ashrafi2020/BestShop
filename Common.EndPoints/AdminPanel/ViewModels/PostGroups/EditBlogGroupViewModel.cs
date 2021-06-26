using System.ComponentModel.DataAnnotations;

namespace Common.EndPoints.AdminPanel.ViewModels.PostGroups
{
    public class EditBlogGroupViewModel
    {
        public long Id { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "عنوان گروه را وارد کیند")]
        [MaxLength(400, ErrorMessage = ValidationMessages.MaxLength)]
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