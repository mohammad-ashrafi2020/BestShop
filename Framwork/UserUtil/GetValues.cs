using System;
using System.Security.Claims;

namespace framework.UserUtil
{
    public static partial class GetValues
    {
        public static long GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return Convert.ToInt64(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
        public static string GetValueFromClaim(this ClaimsPrincipal principal, string type)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(type)?.Value;
        }
        public static string GetUserRole(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.Role)?.Value;
        }
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.Email)?.Value;
        }
        public static string GetUserPhone(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.MobilePhone)?.Value;
        }
    }
}