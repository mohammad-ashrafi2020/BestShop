using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using framework.DateUtil;
using Microsoft.AspNetCore.Http;

namespace framework.Utilities
{
    public static class TextHelper
    {
        public static string GenerateUniText()
        {
            return Guid.NewGuid() + DateTime.Now.ToPersianDate().Replace("/", "")
                                  + DateTime.Now.TimeOfDay.ToString()
                                      .Replace(":", "")
                                      .Replace(".", "");
        }
        public static Guid GenerateGUID()
        {
            return Guid.NewGuid();
        }
        public static string GenerateUniText(IFormFile fileInput)
        {
            return Guid.NewGuid() + DateTime.Now.ToPersianDate().Replace("/", "")
                                  + DateTime.Now.TimeOfDay.ToString()
                                      .Replace(":", "")
                                      .Replace(".", "") + Path.GetExtension(fileInput.FileName);
        }
        public static bool IsText(this string value)
        {
            var isNumber = Regex.IsMatch(value, @"^\d+$");
            return !isNumber;
        }

        public static string ToSlug(this string text)
        {
            return text.Trim().ToLower()
                .Replace("$", "")
                .Replace(" ","-")
                .Replace("%", "")
                .Replace("^", "")
                .Replace("*", "")
                .Replace("@", "")
                .Replace("!", "")
                .Replace("&", "")
                .Replace("?", "")
                .Replace("=", "")
                .Replace("~", "");
        }
        public static bool IsUniCode(this string value)
        {
            return value.Any(c => c > 255);
        }
        public static string Subscribe(this string text, int length)
        {
            if (text.Length > length)
            {
                return text.Substring(0, length - 3) + "...";
            }

            return text;
        }
        public static string GenerateCode(int length)
        {
            var random = new Random();
            var code = "";
            for (int i = 0; i < length; i++)
            {
                code += random.Next(0, 9).ToString();
            }

            return code;
        }
        public static string ConvertHtmlToText(this string text)
        {
            return Regex.Replace(text, "<.*?>", " ").Replace(":&nbsp;", " ");
        }
    }
}
