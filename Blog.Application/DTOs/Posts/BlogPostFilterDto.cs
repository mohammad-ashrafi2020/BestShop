using System.Collections.Generic;
using framework;

namespace Blog.Application.DTOs.Posts
{
    public class BlogPostFilterDto:BasePaging
    {
        public List<BlogPostDto> Posts { get; set; }
        public string Search { get; set; }
        public string GroupName { get; set; }
        public string Type { get; set; }
    }

   
}