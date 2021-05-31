using System.ComponentModel.DataAnnotations;
using Account.Application.ValidationMessages;

namespace Account.Application.Models.DTOs.Auth
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = AccountValidations.Required)]
        public string Email { get; set; }
    }
}