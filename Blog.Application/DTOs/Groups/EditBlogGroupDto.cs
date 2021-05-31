using System.ComponentModel.DataAnnotations;
using Blog.Application.ValidationMessages;

namespace Blog.Application.DTOs.Groups
{
    public class EditBlogGroupDto
    {
        public long Id { get; set; }
        [Required(ErrorMessage = BlogValidations.Required)]
        [MaxLength(400, ErrorMessage = BlogValidations.MaxLength)]
        public string GroupTitle { get; set; }
        [MaxLength(400, ErrorMessage = BlogValidations.MaxLength)]
        [Required(ErrorMessage = BlogValidations.Required)]
        public string EnglishGroupTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = BlogValidations.Required)]
        [MaxLength(500, ErrorMessage = BlogValidations.MaxLength)]
        public string MetaDescription { get; set; }

        public long? ParentId { get; set; }
    }
}