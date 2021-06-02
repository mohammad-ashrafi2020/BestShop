using System;
using System.ComponentModel.DataAnnotations;
using framework.SecurityUtil.CustomValidation.IFormFile;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.ViewModels.Posts
{
    public class InsertBlogPostDto
    {
        public Guid AuthorId { get; set; }
        [Required(ErrorMessage = "عنوان مقاله را وارد کنید")]
        public string Title { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string UrlTitle { get; set; }
        [Required(ErrorMessage = framework.ValidationMessages.Required)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        public string Description { get; set; }

        [Required(ErrorMessage = "عکس پست را انتخاب کنید")]
        [FileImage(ErrorMessage = "شما فقط قادر به وارد کردن عکس می باشید")]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = framework.ValidationMessages.Required)]
        public string ImageAlt { get; set; }

        [Required(ErrorMessage = framework.ValidationMessages.Required)]
        public string Tags { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "اطلاعات نامعتبر است")]
        public int TimeRequiredToStudy { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "گروه را انتخاب کنید")]
        public Guid GroupId { get; set; }

        public Guid? SubGroupId { get; set; }

        public DateTime DateRelease { get; set; }
        [Display(Name = "پست ویژه")]
        public bool IsSpecial { get; set; }

        [Display(Name = "وضعیت : فعال")]
        public bool IsActive { get; set; }
    }
}