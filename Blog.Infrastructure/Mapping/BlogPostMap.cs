using Blog.Domain.Entities;
using Blog.Domain.Entities.BlogPostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Mapping
{
    public class BlogPostMap : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable("BlogPosts", "dbo");
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.ShortLink).IsUnique();
            builder.HasIndex(b => b.UrlTitle).IsUnique();
            builder.Property(b => b.CreationDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(400);

            builder.Property(b => b.ImageName)
                .IsRequired()
                .HasMaxLength(110)
                .IsUnicode(false);

            builder.Property(b => b.ShortLink)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.ImageAlt)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.MetaDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.Tags)
                .IsRequired()
                .HasMaxLength(800);

            builder.Property(b => b.UrlTitle)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(400);


            builder.HasOne(b => b.Group)
                .WithMany(b => b.MainBlogPosts)
                .HasForeignKey(b => b.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.SubGroup)
                .WithMany(b => b.SubBlogPosts)
                .HasForeignKey(b => b.SubGroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}