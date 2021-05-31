using System;
using System.ComponentModel.DataAnnotations;
using Account.Application.ValidationMessages;
using Account.Domain.Enums;
using framework.SecurityUtil.CustomValidation.IFormFile;
using Microsoft.AspNetCore.Http;

namespace Account.Application.Models.DTOs.Account
{
    public class EditUserDto
    {
        public long UserId { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        public string Name { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        public string Family { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        [MaxLength(10, ErrorMessage = AccountValidations.InvalidNationalCode)]
        [MinLength(10, ErrorMessage = AccountValidations.InvalidNationalCode)]
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        [FileImage(ErrorMessage = "شما فقط قادر به آپلود عکس می باشید")]
        public IFormFile ImageName { get; set; }
        [UIHint("Select2")]
        public Gender Gender { get; set; }
        [UIHint("dateSelect")]
        public string BirthDate { get; set; }
    }
}