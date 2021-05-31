using Blog.Domain.Entities;
using Blog.Domain.Entities.BlogPostAggregate;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Context
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }
        public DbSet<BlogPostGroup> BlogPostGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}