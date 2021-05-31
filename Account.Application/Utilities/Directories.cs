namespace Account.Application.Utilities
{
    public class Directories
    {
        public static string UserAvatar = "wwwroot/account/images/users/avatar";
        public static string BitMapUserAvatar = "wwwroot/account/images/users/avatar/bitMap";
        public static string GetUserAvatar(string imageName) => $"{UserAvatar.Replace("wwwroot", "")}/{imageName}";
        public static string GetBitMapUserAvatar(string imageName) => $"{BitMapUserAvatar.Replace("wwwroot", "")}/{imageName}";
    }
}