using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;

namespace ServiceHost.Infrastructure.Security
{
    public class Identity : IIdentity
    {
        private IHttpContextAccessor _accessor;
        private IConfiguration _configuration;

        public Identity(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            _configuration = configuration;
        }

        public string? AuthenticationType { get; }

        public bool IsAuthenticated
        {
            get
            {

                var token = _accessor.HttpContext.Request.Cookies["BestShopCookie"];
                if (!string.IsNullOrWhiteSpace(token))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var secretKey = _configuration["AppConfig:JwtSecretKey"];
                    var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

                    var validationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateIssuer = true,
                        ValidIssuer = "https://localhost:44319/",
                        ValidateAudience = true,
                        ValidAudience = _configuration["AppConfig:Audience"],
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
                return false;
            }
        }

        public string? Name { get; }
    }
}