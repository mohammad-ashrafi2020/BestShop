using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Addresses;
using Account.Domain.Entities.Users;
using framework;

namespace Account.Application.Services.Users.Addresses
{
    public interface IUserAddressService
    {
        Task<ResultModel<UserAddress>> GetAddressById(long addressId);
        Task<ResultModel<UserAddress>> GetDefaultUserAddress(long userId);
        Task<ResultModel<List<UserAddress>>> GetUserAddresses(long userId);
        Task<bool> AddressIsExistBy(long addressId);
        Task<bool> AddressIsExistBy(long addressId,long userId);
        Task<ResultModel> InsertAddress(InsertAddressDto model);
        Task<ResultModel> EditAddress(EditAddressDto model);
        Task<ResultModel> DeleteAddress(long userId, long addressId);
        Task<ResultModel> SetDefaultAddress(long userId, long addressId);
    }
}