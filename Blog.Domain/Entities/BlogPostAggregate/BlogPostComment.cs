using framework.Domain;

namespace Blog.Domain.Entities.BlogPostAggregate
{
    public class BlogPostComment:BaseSoftDelete
    {
        public long PostId { get; set; }
        public long UserId { get; set; }
        public string CommentText { get; set; }
        public long? ParentId { get; set; }


        public BlogPost BlogPost { get; set; }
    }
}