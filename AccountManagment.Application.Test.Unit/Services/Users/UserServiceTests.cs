using System;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Account;
using Account.Application.Models.DTOs.Auth;
using Account.Application.Services.Emails;
using Account.Application.Services.Users;
using Account.Application.Tests.Fixture;
using Account.Application.Tests.Utils.Users;
using Account.Application.ValidationMessages;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;
using AutoMapper;
using FluentAssertions;
using framework;
using framework.DateUtil;
using NSubstitute;
using Xunit;

namespace Account.Application.Tests.Services.Users
{
    [Collection("DataBase Collection")]
    public class UserServiceTests:IClassFixture<PublicFixture>
    {
        private readonly UserService _UserService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly AccountContext _context;
        private readonly UserUtil _userUtil;
        public UserServiceTests(PublicFixture fixture)
        {
            _emailService = Substitute.For<IEmailService>();
            _context = fixture._context;
            _userUtil=new UserUtil(fixture._context);
            _mapper = Substitute.For<IMapper>();
            _UserService = new UserService(_context, _mapper, _emailService);
        }

        [Fact(DisplayName = "GetUserByFilter")]
        public async Task Should_ReturnUsers_With_Filter()
        {
            //act
            var users = await _UserService.GetUsersByFilter(1, 10, "email@g.com",
                "09175880542", "238", "true", "mohammad");

            //asserts
            Assert.True(users.Status == ResultModelStatus.Success);
        }

        #region GetUsers

        [Theory(DisplayName = "GetUserByPhoneNumber")]
        [InlineData("09176889056")]
        public async Task Should_ReturnUser_WithPhoneNumber_when_UserExist(string phoneNumber)
        {
            //Arrange
            var created = _userUtil.AddUser( phoneNumber: phoneNumber);

            //act
            var user = await _UserService.GetUserBy(phoneNumber);

            //Asserts
            Assert.True(user.Status == ResultModelStatus.Success);

            //Clean
            UserUtil.ClearUser(created, _context);
        }

        [Theory(DisplayName = "GetUserByPhoneNumber")]
        [InlineData("09351171198")]
        public async Task Should_ReturnUserNotFound_WithPhoneNumber_When_UserNotExist(string phoneNumber)
        {
            //
            var created = _userUtil.AddUser( phoneNumber: "09175880542");


            //act
            var user = await _UserService.GetUserBy(phoneNumber);

            //Asserts
            Assert.True(user.Status == ResultModelStatus.NotFound);

            //Clean
            UserUtil.ClearUser(created, _context);
        }

        [Fact(DisplayName = "GetUserById")]
        public async Task Should_ReturnUser_WithUserId_when_UserExist()
        {
            //Arrange
            var created = _userUtil.AddUser();

            //act
            var user = await _UserService.GetUserBy(created.Id);

            //Asserts
            Assert.True(user.Status == ResultModelStatus.Success);

            //Clean
            UserUtil.ClearUser(created, _context);
        }

        [Fact(DisplayName = "GetUserById")]
        public async Task Should_ReturnUserNotFound_WithUserId_when_UserNotExist()
        {
            //Arrange
            var created = _userUtil.AddUser();

            //act
            var user = await _UserService.GetUserBy(created.Id + 1);
            //Asserts
            Assert.True(user.Status == ResultModelStatus.NotFound);
            UserUtil.ClearUser(created, _context);
        }

        [Fact(DisplayName = "GetUserByEmail")]
        public async Task Should_ReturnUser_WithEmail_When_UserExist()
        {
            //Arrange
            var created = _userUtil.AddUser( email: "game.bikar@gmail.com");

            //act
            var user = await _UserService.GetUserByEmail(created.Email);

            //Asserts
            Assert.True(user.Status == ResultModelStatus.Success);

            //Clean
            UserUtil.ClearUser(created, _context);
        }

        [Fact(DisplayName = "GetUserByEmail")]
        public async Task Should_ReturnUserNotFound_WithEmail_When_UserNotExist()
        {
            //Arrange
            var created = _userUtil.AddUser( email: "game.bikar@gmail.com");

            //act
            var user = await _UserService.GetUserByEmail("test@test.com");

            //Asserts
            Assert.True(user.Status == ResultModelStatus.NotFound);

            //Clean
            UserUtil.ClearUser(created, _context);
        }

        [Fact(DisplayName = "GetUserByNationalCode")]
        public async Task Should_ReturnUser_WitNationalCode_When_UserExist()
        {
            //Arrange
            var created = _userUtil.AddUser( nationalCode: "2380472327");

            //act
            var user = await _UserService.GetUserByNationalCode(created.NationalCode);

            //Asserts
            Assert.True(user.Status == ResultModelStatus.Success);

            //Clean
            UserUtil.ClearUser(created, _context);
        }

        [Fact(DisplayName = "GetUserByNationalCode")]
        public async Task Should_ReturnUserNotFound_WithNationalCode_When_UserNotExist()
        {
            //Arrange
            var created = _userUtil.AddUser( nationalCode: "2380472327");

            //act
            var user = await _UserService.GetUserByNationalCode("2380000000");

            //Asserts
            Assert.True(user.Status == ResultModelStatus.NotFound);

            //Clean
            UserUtil.ClearUser(created, _context);
        }
        #endregion

        #region UserExist
        [Fact(DisplayName = "IsUserExistByUserId")]
        public async Task UserExist_With_userId_Should_Return_Success_When_UserExist()
        {
            //Arrange
            var created = _userUtil.AddUser();

            //act
            var userExist = await _UserService.IsUserExist(created.Id);

            //Asserts
            Assert.True(userExist);


            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "IsUserExistByUserId")]
        public async Task UserExist_With_userId_Should_Return_NotFound_When_UserNotExist()
        {
            //Arrange
            var created = _userUtil.AddUser();

            //act
            var userExist = await _UserService.IsUserExist(created.Id + 1);

            //Asserts
            Assert.False(userExist);


            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "IsUserExistByPhoneNumber")]
        public async Task UserExist_With_phoneNumber_Should_Return_Success_When_UserExist()
        {
            //Arrange
            var created = _userUtil.AddUser();

            //act
            var userExist = await _UserService.IsUserExist(created.PhoneNumber);

            //Asserts
            Assert.True(userExist);


            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "IsUserExistByPhoneNumber")]
        public async Task UserExist_With_phoneNumber_Should_Return_NotFound_When_UserNotExist()
        {
            //Arrange
            var created = _userUtil.AddUser( phoneNumber: "09175880542");

            //act
            var userExist = await _UserService.IsUserExist("09170000000");

            //Asserts
            Assert.False(userExist);


            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "IsUserExistByNationalCode")]
        public async Task UserExist_With_NationalCode_Should_Return_Success_When_UserExist()
        {
            //Arrange
            var created = _userUtil.AddUser();

            //act
            var userExist = await _UserService.IsUserExistByNationalCode(created.NationalCode);

            //Asserts
            Assert.True(userExist);


            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "IsUserExistByNationalCode")]
        public async Task UserExist_With_NationalCode_Should_Return_NotFound_When_UserNotExist()
        {
            //Arrange
            var created = _userUtil.AddUser( nationalCode: "2380472327");

            //act
            var userExist = await _UserService.IsUserExistByNationalCode("2380000000");

            //Asserts
            Assert.False(userExist);


            //Clean
            UserUtil.ClearUser(created, _context);
        }

        [Fact(DisplayName = "IsUserExistByEmail")]
        public async Task UserExist_With_Email_Should_Return_Success_When_UserExist()
        {
            //Arrange
            var created = _userUtil.AddUser();

            //act
            var userExist = await _UserService.IsUserExistByEmail(created.Email);

            //Asserts
            Assert.True(userExist);


            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "IsUserExistByEmail")]
        public async Task UserExist_With_Email_Should_Return_NotFound_When_UserNotExist()
        {
            //Arrange
            var created = _userUtil.AddUser( email: "Test@test.com");

            //act
            var userExist = await _UserService.IsUserExistByEmail("Game.bikar@gmail.com");

            //Asserts
            Assert.False(userExist);


            //Clean
            UserUtil.ClearUser(created, _context);
        }

        #endregion

        #region ChangePassword

        [Fact(DisplayName = "ChangePassword")]
        public async Task ChangePassword_Should_ChangeUserPassword_And_ReturnSuccess_When_Data_IsOk()
        {
            //Arrange
            var created = _userUtil.AddUser( password: "123456");
            var passwordDto = new ChangePasswordDto()
            {
                CurrentPassword = "123456",
                Password = "123",
                RePassword = "123",
                UserId = created.Id
            };

            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(UserUtil.ConvertUserToDto(created));
            _mapper.Map<User>(Arg.Any<UserDto>()).Returns(created);
            var result = await _UserService.ChangePassword(passwordDto);

            //Asserts
            Assert.True(result.Status == ResultModelStatus.Success);


            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "ChangePassword")]
        public async Task ChangePassword_Should_ReturnError_When_CurrentPassword_NotValid()
        {
            //Arrange
            var created = _userUtil.AddUser( password: "123456");
            var passwordDto = new ChangePasswordDto()
            {
                CurrentPassword = "123",
                Password = "123",
                RePassword = "123",
                UserId = created.Id
            };

            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(UserUtil.ConvertUserToDto(created));
            _mapper.Map<User>(Arg.Any<UserDto>()).Returns(created);
            var result = await _UserService.ChangePassword(passwordDto);

            //Asserts
            Assert.True(result.Status == ResultModelStatus.Error);
            result.Message.Should().Be(AccountValidations.CurrentPasswordInValid);

            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "ChangePassword")]
        public async Task ChangePassword_Should_ReturnError_When_Password_Not_Compare_RePassword()
        {
            //Arrange
            var created = _userUtil.AddUser( password: "123456");
            var passwordDto = new ChangePasswordDto()
            {
                CurrentPassword = "123456",
                Password = "123",
                RePassword = "1234",
                UserId = created.Id
            };

            //Act
            var result = await _UserService.ChangePassword(passwordDto);

            //Asserts
            Assert.True(result.Status == ResultModelStatus.Error);
            result.Message.Should().Be(AccountValidations.PasswordNotCompareRePassword);

            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "ChangePassword")]
        public async Task ChangePassword_Should_ReturnError_When_UserNotFound()
        {
            //Arrange
            var passwordDto = new ChangePasswordDto()
            {
                CurrentPassword = "123456",
                Password = "123",
                RePassword = "123",
                UserId = -1
            };

            //Act
            var result = await _UserService.ChangePassword(passwordDto);

            //Asserts
            Assert.True(result.Status == ResultModelStatus.Error);
            result.Message.Should().Be("عملیات ناموفق");
        }
        #endregion

        #region ResetPassword

        [Fact(DisplayName = "ResetPassword")]
        public async Task ResetPassword_Should_ReturnSuccess_when_Data_IsOk()
        {
            //Arrange
            var created = _userUtil.AddUser( "mohammad@ashrafi.com");
            var resetModel = new ResetPasswordDto()
            {
                ActivationToken = created.ActivationToken,
                Email = created.Email,
                Password = "123",
                RePassword = "123"
            };
            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(UserUtil.ConvertUserToDto(created));
            _mapper.Map<User>(Arg.Any<UserDto>()).Returns(created);
            var res = await _UserService.ResetPassword(resetModel);
            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);

            //Clear
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "ResetPassword")]
        public async Task ResetPassword_Should_ReturnNotFound_when_UserNotFound()
        {
            //Arrange
            var created = _userUtil.AddUser( "mohammad@ashrafi.com");
            var resetModel = new ResetPasswordDto()
            {
                ActivationToken = created.ActivationToken,
                Email = "test@ashrafi.com",
                Password = "123",
                RePassword = "123"
            };
            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(UserUtil.ConvertUserToDto(created));
            _mapper.Map<User>(Arg.Any<UserDto>()).Returns(created);
            var res = await _UserService.ResetPassword(resetModel);
            //Asserts

            Assert.True(res.Status == ResultModelStatus.NotFound);
            //Clear
            UserUtil.ClearUser(created, _context);

        }
        [Fact(DisplayName = "ResetPassword")]
        public async Task ResetPassword_Should_ReturnError_when_TokenNotValid()
        {
            //Arrange
            var created = _userUtil.AddUser( "mohammad@ashrafi.com");
            var newGuild = Guid.NewGuid();

            while (newGuild == created.ActivationToken)
            {
                newGuild = Guid.NewGuid();
            }

            var resetModel = new ResetPasswordDto()
            {
                ActivationToken = newGuild,
                Email = "mohammad@ashrafi.com",
                Password = "123",
                RePassword = "123"
            };
            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(UserUtil.ConvertUserToDto(created));
            _mapper.Map<User>(Arg.Any<UserDto>()).Returns(created);
            var res = await _UserService.ResetPassword(resetModel);
            //Asserts

            Assert.True(res.Status == ResultModelStatus.Error);

            //Clear
            UserUtil.ClearUser(created, _context);

        }
        [Fact(DisplayName = "ResetPassword")]
        public async Task ResetPassword_Should_ReturnError_when_Password_Not_Compare_RePassword()
        {
            //Arrange
            var created = _userUtil.AddUser( "mohammad@ashrafi.com");

            var resetModel = new ResetPasswordDto()
            {
                ActivationToken = created.ActivationToken,
                Email = "mohammad@ashrafi.com",
                Password = "123",
                RePassword = "1234"
            };
            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(UserUtil.ConvertUserToDto(created));
            _mapper.Map<User>(Arg.Any<UserDto>()).Returns(created);
            var res = await _UserService.ResetPassword(resetModel);
            //Asserts
            Assert.True(res.Status == ResultModelStatus.Error);
            res.Message.Should().Be(AccountValidations.PasswordNotCompareRePassword);

            //Clear
            UserUtil.ClearUser(created, _context);

        }
        #endregion

        #region ForgotPassword

        [Fact(DisplayName = "ForgotPassword")]
        public async Task Should_Return_Success_when_UserExist()
        {
            //Arrange
            var created = _userUtil.AddUser( "mohammad@ashrafi.com");
            var forgotModel = new ForgotPasswordDto()
            {
                Email = created.Email
            };
            var userDto = UserUtil.ConvertUserToDto(created);

            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(userDto);
            var res = await _UserService.ForgotPassword(forgotModel);

            //Asserts
            Received.InOrder(() =>
            {
                _emailService.SendForgotPassword(userDto, Arg.Any<string>());
                Assert.True(res.Status == ResultModelStatus.Success);
            });

            //Clean
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "ForgotPassword")]
        public async Task Should_Return_NotFound_when_UserNotExist()
        {
            //Arrange
            var created = _userUtil.AddUser( "mohammad@ashrafi.com");
            var forgotModel = new ForgotPasswordDto()
            {
                Email = "FakeTest@Fake.com"
            };

            //Act
            var res = await _UserService.ForgotPassword(forgotModel);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);

            //Clean
            UserUtil.ClearUser(created, _context);
        }

        #endregion

        #region Register

        [Fact(DisplayName = "RegisterUser")]
        public async Task Should_ReturnSuccess_When_Data_Input_IsOk()
        {
            //Arrange
            var registerDto = new RegisterDto()
            {
                IsAcceptRules = true,
                Password = "123456",
                PhoneNumber = "09175880542",
                RePassword = "123456"
            };
            //Act
            var res = await _UserService.RegisterUser(registerDto);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);

            //Clean
            _userUtil.ClearUser(registerDto.PhoneNumber);
        }

        [Fact(DisplayName = "RegisterUser")]
        public async Task Should_ReturnError_When_Format_PhoneNumber_IsText()
        {
            //Arrange
            var registerDto = new RegisterDto()
            {
                IsAcceptRules = true,
                Password = "123456",
                PhoneNumber = "salam",
                RePassword = "123456"
            };

            //Act
            var res = await _UserService.RegisterUser(registerDto);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Error);
            res.Message.Should().Be(AccountValidations.InvalidPhoneNumber);

            //Clean
        }

        [Fact(DisplayName = "RegisterUser")]
        public async Task Should_ReturnError_When_PhoneNumber_IsExist_InDataBase()
        {
            //Arrange
            var created = _userUtil.AddUser( phoneNumber: "09175880542");
            var registerDto = new RegisterDto()
            {
                IsAcceptRules = true,
                Password = "123456",
                PhoneNumber = "09175880542",
                RePassword = "123456"
            };

            //Act
            var res = await _UserService.RegisterUser(registerDto);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Error);
            res.Message.Should().Be("شماره تلفن وارد شده تکراری می باشد");

            //Clean
            UserUtil.ClearUser(created, _context);
        }
        #endregion

        #region LoginUser
        [Fact(DisplayName = "LoginUser")]
        public async Task LoginUser_Should_Return_UserDto_When_Data_Input_IsOk()
        {
            //Arrange
            const string phoneNumber = "09351171196";
            const string password = "123456";
            var created = _userUtil.AddUser( password: password, phoneNumber: phoneNumber);
            var loginModel = new LoginDto()
            {
                Password = password,
                PhoneNumber = phoneNumber
            };
            var expectedValue = UserUtil.ConvertUserToDto(created);
            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(expectedValue);
            var res = await _UserService.LoginUser(loginModel);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            res.Data.Should().Be(expectedValue);

            //Clean
            UserUtil.ClearUser(created, _context);
        }

        [Fact(DisplayName = "LoginUser")]
        public async Task LoginUser_Should_ReturnNotFound_When_PhoneNumber_NotExist()
        {
            //Arrange
            const string phoneNumber = "09351171196";
            const string password = "123456";
            var created = _userUtil.AddUser( password: password, phoneNumber: phoneNumber);
            var loginModel = new LoginDto()
            {
                Password = password,
                PhoneNumber = "0935000000"
            };
            var expectedValue = UserUtil.ConvertUserToDto(created);
            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(expectedValue);
            var res = await _UserService.LoginUser(loginModel);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);

            //Clean
            UserUtil.ClearUser(created, _context);
        }

        [Fact(DisplayName = "LoginUser")]
        public async Task LoginUser_Should_ReturnNotFound_When_Password_InValid()
        {
            //Arrange
            const string phoneNumber = "09351171196";
            const string password = "123456";
            var created = _userUtil.AddUser( password: password, phoneNumber: phoneNumber);
            var loginModel = new LoginDto()
            {
                Password = "123",
                PhoneNumber = phoneNumber
            };
            var expectedValue = UserUtil.ConvertUserToDto(created);
            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(expectedValue);
            var res = await _UserService.LoginUser(loginModel);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);

            //Clean
            UserUtil.ClearUser(created, _context);
        }
        #endregion

        #region EditUser

        [Fact(DisplayName = "EditUser")]
        public async Task EditUser_Should_ReturnSuccess_And_Return_UserDto()
        {
            var created = _userUtil.AddUser();
            //Arrange
            var editDto = new EditUserDto()
            {
                Email = created.Email + "M",
                Name = created.Name + "M",
                Family = created.Family,
                NationalCode = created.NationalCode,
                Gender = created.Gender,
                BirthDate = DateTime.Now.ToPersianDate(),
                ImageName = null,
                IsActive = true,
                UserId = created.Id
            };
            var userEdited = created;
            userEdited.Email = editDto.Email;
            userEdited.Name = editDto.Name;

            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(UserUtil.ConvertUserToDto(created));
            _mapper.Map<User>(Arg.Any<UserDto>()).Returns(userEdited);
            var res = await _UserService.EditUser(editDto);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            res.Data.Email.Should().Be(userEdited.Email.ToLower());
            res.Data.Name.Should().Be(userEdited.Name);

            //CleanUp
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "EditUser")]
        public async Task EditUser_Should_ReturnNotFound_When_UserId_InValid()
        {
            var created = _userUtil.AddUser();
            //Arrange
            var editDto = new EditUserDto()
            {
                Email = created.Email + "M",
                Name = created.Name + "M",
                Family = created.Family,
                NationalCode = created.NationalCode,
                Gender = created.Gender,
                BirthDate = DateTime.Now.ToPersianDate(),
                ImageName = null,
                IsActive = true,
                UserId = created.Id + 1
            };

            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(UserUtil.ConvertUserToDto(created));
            var res = await _UserService.EditUser(editDto);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);


            //CleanUp
            UserUtil.ClearUser(created, _context);
        }
        [Fact(DisplayName = "EditUser")]
        public async Task EditUser_Should_ReturnError_When_EmailExist()
        {
            var created = _userUtil.AddUser();
            var created2 = _userUtil.AddUser( email: created.Email + "m");
            //Arrange
            var editDto = new EditUserDto()
            {
                Email = created.Email + "m",
                Name = created.Name + "M",
                Family = created.Family,
                NationalCode = created.NationalCode,
                Gender = created.Gender,
                BirthDate = DateTime.Now.ToPersianDate(),
                ImageName = null,
                IsActive = true,
                UserId = created.Id + 1
            };

            //Act
            _mapper.Map<UserDto>(Arg.Any<User>()).Returns(UserUtil.ConvertUserToDto(created));
            var res = await _UserService.EditUser(editDto);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Error);
            res.Message.Should().Be(AccountValidations.EmailExist);

            //CleanUp
            UserUtil.ClearUser(created, _context);
            UserUtil.ClearUser(created2, _context);
        }
        #endregion
    }
}