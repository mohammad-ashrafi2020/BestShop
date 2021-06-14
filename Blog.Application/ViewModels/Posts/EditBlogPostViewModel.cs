﻿using System;
using System.ComponentModel.DataAnnotations;
using framework.SecurityUtil.CustomValidation.IFormFile;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.ViewModels.Posts
{
    public class EditBlogPostViewModel
    {
        public long Id { get; set; }
        public Guid AuthorId { get; set; }

        [Display(Name = "عنوان مقاله")]
        [Required(ErrorMessage = "عنوان مقاله را وارد کنید")]
        public string Title { get; set; }


        [Display(Name = "عنوان انگلیسی")]
        [Required(ErrorMessage = "{0} اجباری است")]
        public string UrlTitle { get; set; }

        [Display(Name = "Meta Description")]
        [Required(ErrorMessage = framework.ValidationMessages.Required)]
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }

        [Display(Name = "عکس")]
        [FileImage(ErrorMessage = "شما فقط قادر به وارد کردن عکس می باشید")]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }


        [Display(Name = "متن جایگزین عکس (برای Seo) = Alt")]
        [Required(ErrorMessage = framework.ValidationMessages.Required)]
        public string ImageAlt { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [Required(ErrorMessage = framework.ValidationMessages.Required)]
        public string Tags { get; set; }


        [Display(Name = "زمان لازم برای مطالعه (دقیقه)")]
        [Range(1, int.MaxValue, ErrorMessage = "اطلاعات نامعتبر است")]
        public int TimeRequiredToStudy { get; set; }

        [Display(Name = "گروه")]
        [Range(1, int.MaxValue, ErrorMessage = "گروه را انتخاب کنید")]
        public long GroupId { get; set; }


        [Display(Name = "زیر گروه")]
        public long? SubGroupId { get; set; }

        [Display(Name = "زمان انتشار")]
        [UIHint("DateSelect")]
        public string DateRelease { get; set; }
        [Display(Name = "پست ویژه")]
        public bool IsSpecial { get; set; }

        [Display(Name = "وضعیت : فعال")]
        public bool IsActive { get; set; }

        public string ImageName { get; set; }
    }
}