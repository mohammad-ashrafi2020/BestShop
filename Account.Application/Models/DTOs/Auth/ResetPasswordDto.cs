using System;
using System.ComponentModel.DataAnnotations;
using Account.Application.ValidationMessages;

namespace Account.Application.Models.DTOs.Auth
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public Guid ActivationToken { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        [MinLength(7, ErrorMessage = AccountValidations.PasswordMinLength)]
        [MaxLength(50, ErrorMessage = AccountValidations.PasswordMaxLength)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = AccountValidations.PasswordNotCompareRePassword)]
        public string RePassword { get; set; }
    }
}