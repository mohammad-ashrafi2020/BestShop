using System;
using System.Linq;
using Account.Application.Models.DTOs.Account;
using Account.Domain.Entities.Users;
using Account.Domain.Enums;
using Account.Infrastructure.Context;
using framework.SecurityUtil;

namespace Account.Application.Tests.Utils.Users
{
    public class UserUtil
    {
        private AccountContext _context;
        public UserUtil(AccountContext context)
        {
            _context = context;
        }
        public  User AddUser(string email = "test@test.com", string phoneNumber = "09351171196",
            string nationalCode = "2380472327", string password = "123456")
        {
            var user = new User()
            {
                ActivationCode = "123",
                ActivationToken = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                Email = email,
                Family = "ashrafi",
                Name = "mohammad",
                Gender = Gender.Male,
                ImageName = "",
                IsActive = true,
                LastSendCodeDate = DateTime.Now,
                NationalCode = nationalCode,
                Password = password.EncodeToMd5(),
                PhoneNumber = phoneNumber,
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public static User AddUser(AccountContext context,string email = "test@test.com", string phoneNumber = "09351171196",
            string nationalCode = "2380472327", string password = "123456")
        {
            var user = new User()
            {
                ActivationCode = "123",
                ActivationToken = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                Email = email,
                Family = "ashrafi",
                Name = "mohammad",
                Gender = Gender.Male,
                ImageName = "",
                IsActive = true,
                LastSendCodeDate = DateTime.Now,
                NationalCode = nationalCode,
                Password = password.EncodeToMd5(),
                PhoneNumber = phoneNumber,
            };
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
        public static UserDto ConvertUserToDto(User user)
        {
            return new UserDto()
            {
                Name = user.Name,
                Family = user.Family,
                NationalCode = user.NationalCode,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Password = user.Password,
                ActivationCode = user.ActivationCode,
                ActivationToken = user.ActivationToken,
                BirthDate = user.BirthDate,
                CreationDate = user.CreationDate,
                ImageName = user.ImageName,
                IsActive = user.IsActive,
                LastSendCodeDate = user.LastSendCodeDate
            };
        }
        public void ClearUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public static void ClearUser(User user, AccountContext context)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public  void ClearUser(string phoneNumber)
        {
            var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            if (user == null) return;

            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}