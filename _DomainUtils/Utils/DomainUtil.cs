using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _DomainUtils.Utils
{
    public static class DomainUtil
    {
        public static bool Domain_IsText(this string value)
        {
            var isNumber = Regex.IsMatch(value, @"^\d+$");
            return !isNumber;
        }
        public static string Domain_ToSlug(this string value)
        {
            return value.Trim().ToLower().Replace("$", "")
                 .Replace(" ", "-")
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
        public static bool Domain_IsUniCode(this string value)
        {
            return value.Any(c => c > 255);
        }
    }
}
