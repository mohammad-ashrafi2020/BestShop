using Blog.Domain.Entities.BlogPostGroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogPostGroup = Blog.Domain.Entities.BlogPostGroupAggregate.BlogPostGroup;

namespace Blog.Infrastructure.Persistent.EF.Mapping
{
    public class BlogPostGroupMap : IEntityTypeConfiguration<BlogPostGroup>
    {
        public void Configure(EntityTypeBuilder<BlogPostGroup> builder)
        {
            builder.ToTable("BlogPostGroups", "blog");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");


            builder.Property(b => b.GroupTitle)
                .IsRequired()
                .HasMaxLength(400);

            builder.Property(b => b.EnglishGroupTitle)
                .IsRequired()
                .HasMaxLength(400)
                .IsUnicode(false);

            builder.Property(b => b.MetaDescription)
                .IsRequired()
                .HasMaxLength(500);


            builder.HasMany(b=>b.Groups);
        }
    }
}