using System.ComponentModel.DataAnnotations;
using Account.Application.ValidationMessages;

namespace Account.Application.Models.DTOs.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = AccountValidations.Required)]
        [MaxLength(11, ErrorMessage = AccountValidations.InvalidPhoneNumber)]
        [MinLength(11, ErrorMessage = AccountValidations.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = AccountValidations.Required)]
        [MinLength(7, ErrorMessage = AccountValidations.PasswordMinLength)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = AccountValidations.PasswordNotCompareRePassword)]
        [MinLength(7, ErrorMessage = AccountValidations.PasswordMinLength)]
        [MaxLength(50, ErrorMessage = AccountValidations.PasswordMaxLength)]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "برای فعالیت در سایت باید با قوانین موفقت کنید")]
        public bool IsAcceptRules { get; set; } = false;
    }
}