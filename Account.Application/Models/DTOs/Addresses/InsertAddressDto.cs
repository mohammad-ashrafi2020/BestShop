using System.ComponentModel.DataAnnotations;
using Account.Application.ValidationMessages;

namespace Account.Application.Models.DTOs.Addresses
{
    public class InsertAddressDto
    {
        public long UserId { get; set; }
        [Display(Name = "کد پستی")]
        [Required(ErrorMessage = "{0} الزامی است")]
        [MinLength(7, ErrorMessage = AccountValidations.MinLength)]
        [MaxLength(50, ErrorMessage = AccountValidations.MaxLength)]
        public string PostalCode { get; set; }

        [Display(Name = "نشانی پستی")]
        [Required(ErrorMessage = "{0} الزامی است")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public string City { get; set; }

        [Required(ErrorMessage = AccountValidations.Required)]
        public string Shire { get; set; }

        [Required(ErrorMessage = AccountValidations.Required)]
        [MaxLength(80, ErrorMessage = AccountValidations.MaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = AccountValidations.Required)]
        [MaxLength(80, ErrorMessage = AccountValidations.MaxLength)]
        public string Family { get; set; }

        [Required(ErrorMessage = AccountValidations.Required)]
        [MaxLength(11, ErrorMessage = AccountValidations.InvalidPhoneNumber)]
        [MinLength(11, ErrorMessage = AccountValidations.InvalidPhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = AccountValidations.Required)]
        [MaxLength(10, ErrorMessage = AccountValidations.InvalidNationalCode)]
        [MinLength(10, ErrorMessage = AccountValidations.InvalidNationalCode)]
        public string NationalCode { get; set; }
        public bool IsDefaultAddress { get; set; }
    }
    public class EditAddressDto:InsertAddressDto
    {
        public long Id { get; set; }
    }
}