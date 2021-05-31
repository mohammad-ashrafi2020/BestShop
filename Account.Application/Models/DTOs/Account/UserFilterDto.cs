using System.Collections.Generic;
using framework;

namespace Account.Application.Models.DTOs.Account
{
    public class UserFilterDto:BasePaging
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string IsActive { get; set; }
        public List<UserDto> Users { get; set; }
    }
}