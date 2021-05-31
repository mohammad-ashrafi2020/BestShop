﻿using System;
using Account.Application.Models.DTOs.Account;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ServiceHost.Infrastructure.DTOs;

namespace ServiceHost.Infrastructure.Cookies
{
    public static class CookieUtils
    {
        public static void SetUserInfoCookie(UserDto user, HttpContext context, int walletAmount)
        {
            var userInfo = new UserInfo()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FullName = user.FullName,
                WalletAmount = walletAmount,
                ImageName = user.ImageName
            };
            var info = JsonConvert.SerializeObject(userInfo);
            context.Response.Cookies.Append("userInfo", info, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(30)
            });
        }
        public static void SetUserInfoCookie(UserInfo userInfo, HttpContext context)
        {
            var info = JsonConvert.SerializeObject(userInfo);
            context.Response.Cookies.Append("userInfo", info, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(30)
            });
        }
    }
}