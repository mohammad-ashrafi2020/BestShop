using System;
using System.ComponentModel.DataAnnotations;
using Blog.Application.ValidationMessages;
using framework.SecurityUtil.CustomValidation.IFormFile;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.DTOs.Posts
{
    public class EditBlogPostDto
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        [Required(ErrorMessage = "عنوان مقاله را وارد کنید")]
        public string Title { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string UrlTitle { get; set; }
        [Required(ErrorMessage = BlogValidations.Required)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        public string Description { get; set; }
        public string ImageName { get; set; }
        [FileImage(ErrorMessage = "شما فقط قادر به وارد کردن عکس می باشید")]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = BlogValidations.Required)]
        public string ImageAlt { get; set; }
        [Required(ErrorMessage = BlogValidations.Required)]
        public string Tags { get; set; }
        [Range(1,int.MaxValue,ErrorMessage = "اطلاعات نامعتبر است")]
        public int TimeRequiredToStudy { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "گروه را انتخاب کنید")]
        public long GroupId { get; set; }
        public long? SubGroupId { get; set; }
        public DateTime DateRelease { get; set; }
        [Display(Name = "پست ویژه")]
        public bool IsSpecial { get; set; }
        [Display(Name = "وضعیت : فعال")]
        public bool IsActive { get; set; }
    }
}