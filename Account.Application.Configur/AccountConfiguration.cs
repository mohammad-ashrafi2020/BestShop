using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Account.Application;
using Account.Application.Services.Emails;
using Account.Application.Services.Users;
using Account.Application.Services.Users.Addresses;
using Account.Application.Services.Users.Cards;
using Account.Application.Services.Users.Notifications;
using Account.Application.Services.Users.UserRoles;
using Account.Application.Services.Users.Wallets;
using Account.Domain.Entities.Roles;
using Account.Infrastructure.Context;
using AutoMapper;
using framework.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Account.Configuration
{
    public static class AccountConfiguration
    {
        public static void Init(IServiceCollection service, string connectionString, IConfiguration configuration)
        {
            service.Configure<EmailConfig>(configuration.GetSection("EmailConfig"));

            service.AddAutoMapper(typeof(AutoMapperProfile));
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserAddressService, UserAddressService>();
            service.AddScoped<IUserCardService, UserCardService>();
            service.AddScoped<IUserRoleService, UserRoleService>();
            service.AddScoped<IUserNotificationService, UserNotificationService>();
            service.AddTransient<IEmailService, EmailService>();
            service.AddScoped<IUserWalletService, UserWalletService>();

            service.AddDbContext<AccountContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

        }

        public static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration["JwtConfig:JwtSecretKey"];

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateIssuer = true,
                        ValidIssuer = "https://localhost:44319/",
                        ValidateAudience = true,
                        ValidAudience = configuration["JwtConfig:Audience"],
                        ValidateLifetime = true
                    };
                });
        }

       

        public static void UseJwtAuthentication(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var token = context.Request.Cookies["BestShopCookie"];
                if (!string.IsNullOrWhiteSpace(token))
                {
                    context.Request.Headers.Append("Authorization", $"Bearer {token}");
                }

                await next.Invoke();
            });
            app.UseAuthentication();
        }
    }
}