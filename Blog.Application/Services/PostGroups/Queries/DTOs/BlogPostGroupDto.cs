namespace Blog.Application.Services.PostGroups.Queries.DTOs
{
    public class BlogPostGroupDto
    {
        public long Id { get; set; }
        public string GroupTitle { get; set; }
        public string EnglishGroupTitle { get; set; }
        public string Slug { get; set; }
        public long? ParentId { get; set; }
    }
}