using System.Linq;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Addresses;
using Account.Application.Services.Users.Addresses;
using Account.Application.Tests.Fixture;
using Account.Application.Tests.Utils.Addresses;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;
using AutoMapper;
using FluentAssertions;
using framework;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

namespace Account.Application.Tests.Services.Addresses
{
    [Collection("DataBase Collection")]
    public class UserAddressServiceTests
    {

        private readonly PublicFixture _publicFixture;
        private readonly UserAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly AddressUtil _adressUtil;
        public UserAddressServiceTests(PublicFixture publicFixture)
        {
            _publicFixture = publicFixture;
            _mapper = Substitute.For<IMapper>();
            _adressUtil = new AddressUtil(publicFixture._context,publicFixture.UserId);
            _addressService = new UserAddressService(_publicFixture._context, _mapper);
        }

        [Fact(DisplayName = "GetAddressById")]
        public async Task Should_Return_SuccessStatus_And_Return_UserAddress_When_AddressIsExist()
        {
            //Arrange
            var created = _adressUtil.InsertAddress();

            //Act
            var address = await _addressService.GetAddressById(created.Id);
            //Asserts
            Assert.True(address.Status == ResultModelStatus.Success);
            address.Data.Should().NotBeNull();
            //Clean
            _adressUtil.ClearAddress( created);
        }

        [Fact(DisplayName = "GetAddressById")]
        public async Task Should_Return_NotFoundStatus_When_AddressNotExist()
        {
            //Act
            var address = await _addressService.GetAddressById(-1);

            //Asserts
            Assert.True(address.Status == ResultModelStatus.NotFound);

        }

        [Fact(DisplayName = "GetDefaultUserAddress")]
        public async Task Should_Return_DefaultAddress_For_CurrentUser_when_IsExist_AddressDefault()
        {
            //Arrange
            var created = _adressUtil.InsertAddress(isDefaultAddress: true);

            //Act
            var res = await _addressService.GetDefaultUserAddress(_publicFixture.UserId);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            res.Data.Id.Should().Be(created.Id);

            //CleanUp
            _adressUtil.ClearAddress( created);
        }

        [Fact(DisplayName = "GetDefaultUserAddress")]
        public async Task Should_Return_NotFoundStatus_when_User_Does_nt_Have_Default_Address()
        {
            //Arrange
            var created = _adressUtil.InsertAddress();

            //Act
            var res = await _addressService.GetDefaultUserAddress(_publicFixture.UserId);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);

            //CleanUp
            _adressUtil.ClearAddress( created);
        }
        [Fact(DisplayName = "GetUserAddresses")]
        public async Task Should_Return_ListOf_UserAddress_by_UserId()
        {
            //Arrange
            var created = _adressUtil.InsertAddress();
            //Act
            var res = await _addressService.GetUserAddresses(_publicFixture.UserId);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            res.Data.Count.Should().Be(1);

            //Clean
            _adressUtil.ClearAddress( created);
        }
        [Fact(DisplayName = "InsertAddress")]
        public async Task Should_Return_SuccessStatus_And_InsertAddress_To_DataBase()
        {
            //Arrange
            var address = _adressUtil.CreateNewAddressObject(_publicFixture.UserId);
            var insertDto = new InsertAddressDto()
            {
                Name = address.Name,
                Family = address.Family,
                NationalCode = address.NationalCode,
                Address = address.Address,
                City = address.City,
                IsDefaultAddress = true,
                Phone = address.Family,
                PostalCode = address.PostalCode,
                Shire = address.Shire,
                UserId = address.UserId
            };
            //Act
            _mapper.Map<UserAddress>(Arg.Any<InsertAddressDto>()).Returns(address);
            var res = await _addressService.InsertAddress(insertDto);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);

            //Clean
            _adressUtil.ClearAddress( address);
        }

        [Fact(DisplayName = "EditAddress")]
        public async Task Should_Return_SuccessStatus_And_EditAddress()
        {
            //Arrange
            var address = _adressUtil.InsertAddress();
            var editDto = new EditAddressDto()
            {
                Name = address.Name + "edited",
                Family = address.Family,
                NationalCode = address.NationalCode,
                Address = address.Address,
                City = address.City,
                IsDefaultAddress = true,
                Phone = address.Family,
                PostalCode = address.PostalCode,
                Shire = address.Shire,
                UserId = address.UserId,
                Id = address.Id
            };
            //Act
            _mapper.Map<UserAddress>(Arg.Any<EditAddressDto>()).Returns(address);
            var res = await _addressService.EditAddress(editDto);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);

            //Clean
            _adressUtil.ClearAddress( address);
        }
        [Fact(DisplayName = "DeleteAddress")]
        public async Task Should_ReturnSuccessStatus_And_Remove_Address_When_DataIsOk()
        {
            //Arrange
            var addressCreated = _adressUtil.InsertAddress();
            //Act
            var res = await _addressService.DeleteAddress(_publicFixture.UserId, addressCreated.Id);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            //Clean
            _adressUtil.ClearAddress( addressCreated);
        }
        [Fact(DisplayName = "DeleteAddress")]
        public async Task Should_ReturnErrorStatus_When_Address_NotExist()
        {
            //Act
            var res = await _addressService.DeleteAddress(_publicFixture.UserId, -1);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);

        }
        [Fact(DisplayName = "SetDefaultAddress")]
        public async Task Should_returnSuccess_And_SetDefaultAddress()
        {
            //Arrange
            var created = _adressUtil.InsertAddress();

            //Act
            var res = await _addressService.SetDefaultAddress(_publicFixture.UserId, created.Id);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            created.IsDefaultAddress.Should().Be(true);

            //Clean
            _adressUtil.ClearAddress( created);
        }
        [Fact(DisplayName = "SetDefaultAddress")]
        public async Task Should_returnSuccess_And_SetDefaultAddress_When_ExistThe_DefaultAddress()
        {
            //Arrange
            var created = _adressUtil.InsertAddress();
            var created2 = _adressUtil.InsertAddress(true);

            //Act
            var res = await _addressService.SetDefaultAddress(_publicFixture.UserId, created.Id);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            created2.IsDefaultAddress.Should().Be(false);
            created.IsDefaultAddress.Should().Be(true);

            //Clean
            _adressUtil.ClearAddress( created);
            _adressUtil.ClearAddress( created2);
        }
        [Fact(DisplayName = "SetDefaultAddress")]
        public async Task Should_returnNotFound_When_AddressNotFound()
        {
            //Act
            var res = await _addressService.SetDefaultAddress(_publicFixture.UserId, -1);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);
        }
        [Fact(DisplayName = "SetDefaultAddress")]
        public async Task Should_return_ErrorStatus_When_Address_Not_For_UserId()
        {
            //Arrange
            var created = _adressUtil.InsertAddress();

            //Act
            var res = await _addressService.SetDefaultAddress(-1, created.Id);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Error);

            //Clean
            _adressUtil.ClearAddress( created);
        }
    }
}