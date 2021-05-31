using System.Threading.Tasks;
using Account.Application.Models.DTOs.Account;
using Account.Application.Models.DTOs.Auth;
using framework;

namespace Account.Application.Services.Users
{
    public interface IUserService
    {
        #region Gets
        Task<ResultModel<UserFilterDto>> GetUsersByFilter(int pageId, int take, string email,
            string phoneNumber, string nationalCode, string isActive, string name);
        Task<ResultModel<UserDto>> GetUserBy(long userId);
        Task<ResultModel<UserDto>> GetUserBy(string phoneNumber);
        Task<ResultModel<UserDto>> GetUserByEmail(string email);
        Task<ResultModel<UserDto>> GetUserByNationalCode(string nationalCode);

        #endregion

        #region Exists
        Task<bool> IsUserExist(long userId);
        Task<bool> IsUserExist(string phoneNumber);
        Task<bool> IsUserExistByNationalCode(string nationalCode);
        Task<bool> IsUserExistByEmail(string email);
        #endregion

        Task<ResultModel> ChangePassword(ChangePasswordDto changeDto);
        Task<ResultModel> ResetPassword(ResetPasswordDto resetDto);
        Task<ResultModel> ForgotPassword(ForgotPasswordDto forgotDto);
        Task<ResultModel> RegisterUser(RegisterDto registerDto);
        Task<ResultModel<UserDto>> LoginUser(LoginDto loginDto);
        Task<ResultModel<UserDto>> EditUser(EditUserDto editUserDto);
    }
}