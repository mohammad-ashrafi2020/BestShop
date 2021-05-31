using Account.Application.Models.DTOs.Account;
using Account.Domain.Entities.Users;

namespace Account.Application.Utilities.Mapper
{
    public static class UserMapper
    {
        public static UserDto MapUserToUserDto(this User user)
        {
            return new UserDto()
            {
                Email = user.Email,
                Name = user.Name,
                Family = user.Family,
                PhoneNumber = user.PhoneNumber,
                CreationDate = user.CreationDate,
                NationalCode = user.NationalCode,
                ActivationCode = user.ActivationCode,
                ActivationToken = user.ActivationToken,
                BirthDate = user.BirthDate,
                Gender = user.Gender,
                ImageName = user.ImageName,
                IsActive = user.IsActive,
                Password = user.Password,
                LastSendCodeDate = user.LastSendCodeDate
            };
        }
    }
}