using Blog.Domain.Entities.BlogPostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Mapping
{
    public class BlogPostCommentMap : IEntityTypeConfiguration<BlogPostComment>
    {
        public void Configure(EntityTypeBuilder<BlogPostComment> builder)
        {
            builder.ToTable("BlogPostComments", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");


            builder.Property(b => b.CommentText)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(b => b.BlogPost)
                .WithMany(b => b.Comments)
                .HasForeignKey(b => b.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}