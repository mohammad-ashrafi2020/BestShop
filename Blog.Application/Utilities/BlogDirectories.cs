namespace Blog.Application.Utilities
{
    public static class BlogDirectories
    {
        public static string BlogPost(string slug) => $"wwwroot/images/blog/{slug}";
    }
}