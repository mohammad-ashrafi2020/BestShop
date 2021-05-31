using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Addresses;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;
using AutoMapper;
using framework;
using framework.Services;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.Services.Users.Addresses
{
    public class UserAddressService : BaseService, IUserAddressService
    {
        private readonly IMapper _mapper;

        public UserAddressService(AccountContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }


        public async Task<ResultModel<UserAddress>> GetAddressById(long addressId)
        {
            var address = await TableTracking<UserAddress>().SingleOrDefaultAsync(a => a.Id == addressId);
            if (address == null)
                return ResultModel<UserAddress>.NotFound();

            return ResultModel<UserAddress>.Success(address);
        }

        public async Task<ResultModel<UserAddress>> GetDefaultUserAddress(long userId)
        {
            var address = await TableTracking<UserAddress>()
                .FirstOrDefaultAsync(a => a.UserId == userId && a.IsDefaultAddress);

            if (address == null)
                return ResultModel<UserAddress>.NotFound();

            return ResultModel<UserAddress>.Success(address);
        }

        public async Task<ResultModel<List<UserAddress>>> GetUserAddresses(long userId)
        {
            var address = await Table<UserAddress>()
                .Where(a => a.UserId == userId && a.IsDelete == false).ToListAsync();


            return ResultModel<List<UserAddress>>.Success(address);
        }

        public async Task<bool> AddressIsExistBy(long addressId)
        {
            return await Exists<UserAddress>(a => a.Id == addressId);
        }

        public async Task<bool> AddressIsExistBy(long addressId, long userId)
        {
            return await Exists<UserAddress>(a => a.Id == addressId && a.UserId == userId);
        }

        public async Task<ResultModel> InsertAddress(InsertAddressDto model)
        {
            var address = _mapper.Map<UserAddress>(model);

            Insert(address);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> EditAddress(EditAddressDto model)
        {
            var address = _mapper.Map<UserAddress>(model);

            Update(address);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> DeleteAddress(long userId, long addressId)
        {
            var address = await GetAddressById(addressId);
            if (address.Status != ResultModelStatus.Success)
                return ResultModel.NotFound();


            address.Data.IsDelete = true;
            address.Data.DeletedAt = DateTime.Now;
            address.Data.DeletedBy = userId;
            Update(address.Data);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> SetDefaultAddress(long userId, long addressId)
        {
            var address = await GetAddressById(addressId);
            if (address.Status != ResultModelStatus.Success)
                return ResultModel.NotFound();

            if (address.Data.UserId != userId)
                return ResultModel.Error();

            var userAddresses = await GetDefaultUserAddress(userId);
            if (userAddresses.Data != null)
            {
                userAddresses.Data.IsDefaultAddress = false;
                Update(userAddresses.Data);
            }

            address.Data.IsDefaultAddress = true;
            Update(address.Data);
            await Save();

            return ResultModel.Success();
        }
    }
}