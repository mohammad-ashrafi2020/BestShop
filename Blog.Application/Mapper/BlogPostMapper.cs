using Blog.Application.Services.Posts.Queries.DTOs;
using Blog.Domain.Entities.BlogPostAggregate;
using Blog.Domain.Entities.BlogPostGroupAggregate;

namespace Blog.Application.Mapper
{
    public static class BlogPostMapper
    {
        public static BlogPostDto MapBlogPostToDto(BlogPost blogPost)
        {
            return new BlogPostDto()
            {
                AuthorId = blogPost.AuthorId,
                AuthorName = " ",
                CreateDate = blogPost.CreationDate,
                DateRelease = blogPost.DateRelease,
                Description = blogPost.Description,
                Group = blogPost.Group,
                GroupId = blogPost.GroupId,
                Id = blogPost.Id,
                ImageAlt = blogPost.ImageAlt,
                ImageName = blogPost.ImageName,
                IsSpecial = blogPost.IsSpecial,
                MetaDescription = blogPost.MetaDescription,
                ShortLink = blogPost.ShortLink,
                SubGroup = blogPost.SubGroup,
                SubGroupId = blogPost.SubGroupId,
                Tags = blogPost.Tags,
                TimeRequiredToStudy = blogPost.TimeRequiredToStudy,
                Title = blogPost.Title,
                UpdateDate = blogPost.ModifyDate,
                Slug = blogPost.Slug,
                Visit = blogPost.Visit,
                IsActive = !blogPost.IsDelete
            };
        }
    }
}