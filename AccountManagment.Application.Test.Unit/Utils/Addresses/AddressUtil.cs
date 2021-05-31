using System;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;

namespace Account.Application.Tests.Utils.Addresses
{
    public  class AddressUtil
    {
        private readonly AccountContext _context;
        private readonly long _userId;
        public AddressUtil(AccountContext context,long userId)
        {
            _context = context;
            _userId = userId;
        }
        public  UserAddress InsertAddress(bool isDefaultAddress = false)
        {
            var address = new UserAddress()
            {
                Address = "Test",
                City = "Tehran",
                CreationDate = DateTime.Now,
                Family = "Ashrafi",
                IsDelete = false,
                PostalCode = "1234567890",
                IsDefaultAddress = isDefaultAddress,
                Name = "MOhammad",
                NationalCode = "2380472327",
                Phone = "09351171196",
                Shire = "Tehran",
                UserId = _userId,

            };
            _context.Add(address);
            _context.SaveChanges();
            return address;
        }
        public  UserAddress CreateNewAddressObject(long userId, bool isDefaultAddress = true)
        {
            var address = new UserAddress()
            {
                Address = "Test",
                City = "Tehran",
                CreationDate = DateTime.Now,
                Family = "Ashrafi",
                IsDelete = false,
                PostalCode = "1234567890",
                IsDefaultAddress = true,
                Name = "MOhammad",
                NationalCode = "2380472327",
                Phone = "09351171196",
                Shire = "Tehran",
                UserId = userId,

            };
            return address;
        }
        public  void ClearAddress(UserAddress address)
        {
            _context.Remove(address);
            _context.SaveChanges();
        }
    }
}