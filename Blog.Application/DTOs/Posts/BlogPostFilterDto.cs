using System.Collections.Generic;
using framework;
using framework.Domain;
using framework.Domain.Enums;

namespace Blog.Application.DTOs.Posts
{
    public class BlogPostFilterDto:BasePaging
    {
        public List<BlogPostDto> Posts { get; set; }
        public string Search { get; set; }
        public string GroupName { get; set; }
        public string Type { get; set; }
        public SearchOn SearchOn { get; set; }
    }

   
}