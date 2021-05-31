using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Account.Application.Models.DTOs.Account;
using Account.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Account.Configuration
{
    public static class GenerateJwtToken
    {
        public static string Generate(User user, IConfiguration configuration)
        {
            var key = configuration["JwtConfig:JwtSecretKey"];

            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
                },
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        public static string Generate(UserDto user, IConfiguration configuration)
        {
            var key = configuration["JwtConfig:JwtSecretKey"];

            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:44319/",
                audience: configuration["JwtConfig:Audience"],
                claims: new List<Claim>
                {
                    new Claim("Email", user.Email ?? " "),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
                },
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}