using System.ComponentModel.DataAnnotations;
using Account.Application.ValidationMessages;

namespace Account.Application.Models.DTOs.Cards
{
    public class InsertCardDto
    {
        public long UserId { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        [MinLength(16, ErrorMessage = AccountValidations.MinLength)]
        [MaxLength(16, ErrorMessage = AccountValidations.MaxLength)]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        public string ShabaNumber { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        public string OwnerName { get; set; }
        [Required(ErrorMessage = AccountValidations.Required)]
        public string BankName { get; set; }
    }
}