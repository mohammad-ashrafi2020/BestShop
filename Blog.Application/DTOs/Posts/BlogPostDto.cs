using System;
using Blog.Domain.Entities;
using framework.Domain;

namespace Blog.Application.DTOs.Posts
{
    public class BlogPostDto: BaseEntity
    {
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string ImageAlt { get; set; }
        public string Tags { get; set; }
        public string ShortLink { get; set; }
        public int TimeRequiredToStudy { get; set; }
        public long GroupId { get; set; }
        public long? SubGroupId { get; set; }
        public long Visit { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DateRelease { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsActive { get; set; }

        public BlogPostGroup Group { get; set; }
        public BlogPostGroup SubGroup { get; set; }
    }
}