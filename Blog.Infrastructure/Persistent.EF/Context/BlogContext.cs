using Blog.Domain.Entities;
using Blog.Domain.Entities.BlogPostAggregate;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistent.EF.Context 
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostGroup> BlogPostGroups { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}