using System.Collections.Generic;
using Common.Core.Enums;
using framework;

namespace Blog.Application.Services.Posts.Queries.DTOs
{
    public class BlogPostFilterDto:BasePaging
    {
        public List<BlogPostDto> Posts { get; set; }
        public string Search { get; set; }
        public string GroupName { get; set; }
        public SearchOn SearchOn { get; set; }
    }

   
}