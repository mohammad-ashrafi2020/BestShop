using System;
using Blog.Domain.Entities.BlogPostGroupAggregate;

namespace Blog.Application.Services.Posts.Queries.DTOs
{
    public class BlogPostDto
    {
        public long Id { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
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
        public DateTime? UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DateRelease { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsActive { get; set; }

        public BlogPostGroup Group { get; set; }
        public BlogPostGroup SubGroup { get; set; }
    }
}