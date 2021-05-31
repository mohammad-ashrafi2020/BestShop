using Account.Application.Models.DTOs.Account;

namespace Account.Application.Services.Emails
{
    public interface IEmailService
    {
        void SendForgotPassword(UserDto user, string url);
    }
}