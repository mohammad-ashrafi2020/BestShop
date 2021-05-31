using System.Linq;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Account;
using Account.Application.Models.DTOs.Auth;
using Account.Application.Services.Emails;
using Account.Application.Utilities;
using Account.Application.ValidationMessages;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;
using AutoMapper;
using framework;
using framework.DateUtil;
using framework.FileUtil;
using framework.SecurityUtil;
using framework.Services;
using framework.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.Services.Users
{
    public class UserService : BaseService, IUserService
    {
        private IMapper _mapper;
        private IEmailService _emailService;
        private int _bitMapWidthSize = 200;
        private int _bitMapHeightSize = 200;
        public UserService(AccountContext context, IMapper mapper, IEmailService emailService) : base(context)
        {
            _mapper = mapper;
            _emailService = emailService;
        }


        public async Task<ResultModel<UserFilterDto>> GetUsersByFilter(int pageId, int take, string email,
            string phoneNumber, string nationalCode, string isActive, string name)
        {
            var result = Table<User>()
                .Select(s => new UserDto()
                {
                    Email = s.Email,
                    Name = s.Name,
                    Family = s.Family,
                    PhoneNumber = s.PhoneNumber,
                    CreationDate = s.CreationDate,
                    NationalCode = s.NationalCode,
                    ActivationCode = s.ActivationCode,
                    ActivationToken = s.ActivationToken,
                    BirthDate = s.BirthDate,
                    Gender = s.Gender,
                    Id = s.Id,
                    ImageName = s.ImageName,
                    IsActive = s.IsActive,
                    Password = s.Password,
                    LastSendCodeDate = s.LastSendCodeDate
                })
                .OrderByDescending(d => d.CreationDate).AsQueryable();

            if (!string.IsNullOrWhiteSpace(email))
            {
                result = result.Where(r => r.Email.Contains(email));
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                result = result.Where(r => r.FullName.Contains(name));
            }
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                result = result.Where(r => r.PhoneNumber.Contains(phoneNumber));

            }
            if (!string.IsNullOrWhiteSpace(nationalCode))
            {
                result = result.Where(r => r.NationalCode.Contains(nationalCode));
            }
            if (!string.IsNullOrWhiteSpace(isActive))
            {
                if (isActive.ToLower() == "true")
                    result = result.Where(r => r.IsActive);
                else if (isActive.ToLower() == "false")
                    result = result.Where(r => !r.IsActive);
            }
            var skip = (pageId - 1) * take;
            var model = new UserFilterDto()
            {
                Email = email,
                IsActive = isActive,
                Name = name,
                PhoneNumber = phoneNumber,
                NationalCode = nationalCode,
                Users = await result.Skip(skip).Take(take).ToListAsync()
            };
            model.GeneratePaging(result, take, pageId);
            return ResultModel<UserFilterDto>.Success(model);
        }

        public async Task<ResultModel<UserDto>> GetUserBy(long userId)
        {
            var user = await GetById<User>(userId);
            if (user == null)
                return ResultModel<UserDto>.NotFound();

            var converted = _mapper.Map<UserDto>(user);

            return ResultModel<UserDto>.Success(converted);
        }

        public async Task<ResultModel<UserDto>> GetUserBy(string phoneNumber)
        {
            var user = await Table<User>()
                .SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

            if (user == null)
                return ResultModel<UserDto>.NotFound();

            var converted = _mapper.Map<UserDto>(user);

            return ResultModel<UserDto>.Success(converted);
        }

        public async Task<ResultModel<UserDto>> GetUserByEmail(string email)
        {
            var user = await Table<User>()
                .SingleOrDefaultAsync(u => u.Email == email.ToLower());
            if (user == null)
                return ResultModel<UserDto>.NotFound();

            var converted = _mapper.Map<UserDto>(user);

            return ResultModel<UserDto>.Success(converted);
        }

        public async Task<ResultModel<UserDto>> GetUserByNationalCode(string nationalCode)
        {

            var user = await Table<User>()
                .SingleOrDefaultAsync(u => u.NationalCode == nationalCode);
            if (user == null)
                return ResultModel<UserDto>.NotFound();

            var converted = _mapper.Map<UserDto>(user);

            return ResultModel<UserDto>.Success(converted);
        }

        public async Task<bool> IsUserExist(long userId)
        {
            var userExist = await Exists<User>(u => u.Id == userId);
            return userExist;
        }

        public async Task<bool> IsUserExist(string phoneNumber)
        {
            var userExist = await Exists<User>(u => u.PhoneNumber == phoneNumber);
            return userExist;
        }

        public async Task<bool> IsUserExistByNationalCode(string nationalCode)
        {
            var userExist = await Exists<User>(u => u.NationalCode == nationalCode);
            return userExist;
        }

        public async Task<bool> IsUserExistByEmail(string email)
        {
            var userExist = await Exists<User>(u => u.Email == email.ToLower());
            return userExist;
        }

        public async Task<ResultModel> ChangePassword(ChangePasswordDto changeDto)
        {
            var user = await GetUserBy(changeDto.UserId);
            if (user.Status != ResultModelStatus.Success)
                return ResultModel.Error();

            if (changeDto.Password != changeDto.RePassword)
                return ResultModel.Error(AccountValidations.PasswordNotCompareRePassword);

            if (!user.Data.Password.IsCompareMd5Text(changeDto.CurrentPassword))
                return ResultModel.Error(AccountValidations.CurrentPasswordInValid);

            var userModel = _mapper.Map<User>(user.Data);
            userModel.Password = changeDto.Password.EncodeToMd5();
            Update(userModel);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> ResetPassword(ResetPasswordDto resetDto)
        {
            var user = await GetUserByEmail(resetDto.Email);
            if (user.Status != ResultModelStatus.Success)
                return ResultModel.NotFound();

            if (user.Data.ActivationToken != resetDto.ActivationToken)
                return ResultModel.Error();

            if (resetDto.Password != resetDto.RePassword)
                return ResultModel.Error(AccountValidations.PasswordNotCompareRePassword);


            var userModel = _mapper.Map<User>(user.Data);
            userModel.Password = resetDto.Password.EncodeToMd5();
            userModel.ActivationToken = TextHelper.GenerateGUID();
            Update(userModel);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> ForgotPassword(ForgotPasswordDto forgotDto)
        {
            var user = await GetUserByEmail(forgotDto.Email);
            if (user.Data == null)
                return ResultModel.NotFound();

            _emailService.SendForgotPassword(user.Data, $"auth/ResetPassword/{user.Data.Email}/{user.Data.ActivationToken}");
            return ResultModel.Success("لینک تغییر کلمه عبور به ایمیل شما ارسال شد");
        }

        public async Task<ResultModel> RegisterUser(RegisterDto registerDto)
        {
            if (registerDto.PhoneNumber.IsText())
                return ResultModel.Error(AccountValidations.InvalidPhoneNumber);

            if (await Exists<User>(u => u.PhoneNumber == registerDto.PhoneNumber))
                return ResultModel.Error("شماره تلفن وارد شده تکراری می باشد");

            var user = new User()
            {
                PhoneNumber = registerDto.PhoneNumber,
                Password = registerDto.Password.EncodeToMd5(),
                IsActive = true
            };
            Insert(user);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel<UserDto>> LoginUser(LoginDto loginDto)
        {
            var user = await GetUserBy(loginDto.PhoneNumber);

            if (user.Status == ResultModelStatus.NotFound)
                return ResultModel<UserDto>.NotFound();

            if (!user.Data.Password.IsCompareMd5Text(loginDto.Password))
                return ResultModel<UserDto>.NotFound();

            return ResultModel<UserDto>.Success(user.Data);
        }

        public async Task<ResultModel<UserDto>> EditUser(EditUserDto editUserDto)
        {
            var user = await GetUserBy(editUserDto.UserId);
            if (user.Status != ResultModelStatus.Success)
                return ResultModel<UserDto>.NotFound();

            if (editUserDto.Email != user.Data.Email)
            {
                var isExistEmail = await IsUserExistByEmail(editUserDto.Email);

                if (isExistEmail)
                    return ResultModel<UserDto>.Error(AccountValidations.EmailExist);
            }

            if (editUserDto.ImageName != null && editUserDto.ImageName.IsImage())
            {
                user.Data.ImageName = await SaveFileInServer.SaveFile(editUserDto.ImageName, Directories.UserAvatar);
                ImageConvertor.CreateBitMap(Directories.GetUserAvatar(user.Data.ImageName),
                Directories.BitMapUserAvatar, _bitMapWidthSize, _bitMapHeightSize);
            }

            user.Data.Name = editUserDto.Name;
            user.Data.Family = editUserDto.Family;
            user.Data.NationalCode = editUserDto.NationalCode;
            user.Data.Email = editUserDto.Email.ToLower();
            user.Data.IsActive = editUserDto.IsActive;
            if (!string.IsNullOrWhiteSpace(editUserDto.BirthDate))
                user.Data.BirthDate = editUserDto.BirthDate.ToMiladi();
            user.Data.Gender = editUserDto.Gender;
            var userModel = _mapper.Map<User>(user.Data);
            Update(userModel);
            await Save();
            return ResultModel<UserDto>.Success(user.Data);
        }
    }
}