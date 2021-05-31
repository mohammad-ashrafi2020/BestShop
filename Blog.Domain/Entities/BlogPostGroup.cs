using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Entities.BlogPostAggregate;
using framework.Domain;

namespace Blog.Domain.Entities
{
    public class BlogPostGroup:BaseEntity
    {
        public string GroupTitle { get; set; }
        public string EnglishGroupTitle { get; set; }
        public string MetaDescription { get; set; }
        public long? ParentId { get; set; }

        #region Relations

        [ForeignKey("ParentId")]
        public ICollection<BlogPostGroup> Groups { get; set; }
        public ICollection<BlogPost> MainBlogPosts { get; set; }
        public ICollection<BlogPost> SubBlogPosts { get; set; }
        #endregion
    }
}