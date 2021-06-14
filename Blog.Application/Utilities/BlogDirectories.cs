namespace Blog.Application.Utilities
{
    public static class BlogDirectories
    {
        public static string BlogPost = $"wwwroot/images/blog";
        public static string GetBlogPost(string image) => $"{BlogPost.Replace("wwwroot", "")}/{image}";
    }
}