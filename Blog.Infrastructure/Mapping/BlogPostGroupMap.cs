using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Mapping
{
    public class BlogPostGroupMap : IEntityTypeConfiguration<BlogPostGroup>
    {
        public void Configure(EntityTypeBuilder<BlogPostGroup> builder)
        {
            builder.ToTable("BlogPostGroups", "dbo");
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
        }
    }
}