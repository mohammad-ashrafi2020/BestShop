using System.Security.Claims;
using System.Text;
using Account.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Account.Application.Utilities.UserUtil
{
    public static class UserUtil
    {

        public static string GetGender(this Gender gender)
        {
            return gender switch
            {
                Gender.Female => "خانم",
                Gender.Male => "آقا",
                Gender.None => "نامشخص",
                _ => "نامشخص"
            };
        }
    }
}