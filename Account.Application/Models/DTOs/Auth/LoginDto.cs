using System.ComponentModel.DataAnnotations;
using Account.Application.ValidationMessages;

namespace Account.Application.Models.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = AccountValidations.Required)]
        [MaxLength(11,ErrorMessage = AccountValidations.InvalidPhoneNumber)]
        [MinLength(11, ErrorMessage = AccountValidations.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        [MinLength(7,ErrorMessage = AccountValidations.PasswordMinLength)]
        [MaxLength(50, ErrorMessage = AccountValidations.PasswordMaxLength)]
        public string Password { get; set; }
    }
}