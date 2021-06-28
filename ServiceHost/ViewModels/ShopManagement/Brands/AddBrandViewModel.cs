using System.ComponentModel.DataAnnotations;
using Common.Application.Validation.CustomValidation.IFormFile;
using Microsoft.AspNetCore.Http;

namespace AdminPanel.ViewModels.ShopManagement.Brands
{
    public class AddBrandViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        [FileImage(ErrorMessage = "شما فقط قادر به آپلود عکس می باشید")]
        [Display(Name = "انتخاب لگو ")]
        public IFormFile LogoFile { get; set; }

        [FileImage(ErrorMessage = "شما فقط قادر به آپلود عکس می باشید")]
        [Display(Name = "انتخاب عکس ")]
        public IFormFile ImageFile { get; set; }
    }
}