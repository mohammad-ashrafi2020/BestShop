using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServiceHost.Infrastructure.DTOs;

namespace ServiceHost.Infrastructure
{
    public class ApplicationContext : IApplicationContext
    {
        private IHttpContextAccessor _accessor;
        private IConfiguration _configuration;
        private ICookieManager _cookie;

        public ApplicationContext(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            _configuration = configuration;
        }
        public bool IsAuthenticated => _IsAuthenticated();
        public UserInfo GetUserInfo()
        {
            try
            {
                var userString = _accessor.HttpContext.Request.Cookies["userInfo"];
                var user = JsonConvert.DeserializeObject<UserInfo>(userString);
                user.FullName ??= "کاربر مهمان";
                return user;
            }
            catch
            {
                return new UserInfo()
                {
                    FullName = "کاربر مهمان",
                    Email = "",
                    PhoneNumber = "",
                    WalletAmount = 0
                };
            }
        }


        #region Utils
        private bool _IsAuthenticated()
        {
            var token = _accessor.HttpContext.Request.Cookies["BestShopCookie"];
            if (string.IsNullOrWhiteSpace(token)) return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["JwtConfig:JwtSecretKey"];
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = "https://localhost:44319/",
                ValidateAudience = true,
                ValidAudience = _configuration["JwtConfig:Audience"],
                ValidateLifetime = true
            };
            try
            {
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return principal.Identity.IsAuthenticated;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }
}