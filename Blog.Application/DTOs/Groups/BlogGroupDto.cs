namespace Blog.Application.DTOs.Groups
{
    public class BlogGroupDto
    {
        public string GroupTitle { get; set; }
        public string EnglishGroupTitle { get; set; }
        public string MetaDescription { get; set; }
        public long? ParentId { get; set; }
    }
}