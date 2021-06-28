using System.ComponentModel.DataAnnotations;
using Common.Application.Validation.CustomValidation.IFormFile;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ValueObjects;

namespace AdminPanel.ViewModels.ShopManagement.Categories
{
    public class AddShopCategoryViewModel
    {
        [Display(Name = "Meta Description")]
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get;  set; }

        [Display(Name = "Meta KeyWords (کلمات را با - از هم جدا کنید)")]
        public string MetaKeyWords { get;  set; }

        [Display(Name = "Meta Title")]
        public string MetaTitle { get;  set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "Slug")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Slug { get; set; }
        public int? ParentId { get; set; }

        [Display(Name = "انتخاب عکس")]
        [FileImage(ErrorMessage = "شما فقط قادر به آپلود عکس می باشید")]
        public IFormFile ImageFile { get; set; }


        [Display(Name = "نمایش در منو")]
        public bool ShowInMenu { get; set; }
    }
    public class EditShopCategoryViewModel: AddShopCategoryViewModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
    }
}