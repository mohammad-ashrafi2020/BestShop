using System;
using Common.Application;
using Common.Core.Utilities;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IBaseRequest
    {
        public CreatePostCommand(Guid authorId, string title, string slug, string metaDescription, string description, string imageAlt, string tags, int timeRequiredToStudy, long groupId, long? subGroupId, string dateRelease, bool isSpecial, bool isActive, IFormFile imageFile)
        {
            AuthorId = authorId;
            Title = title;
            Slug = slug.ToSlug();
            MetaDescription = metaDescription;
            Description = description;
            ImageAlt = imageAlt;
            Tags = tags;
            TimeRequiredToStudy = timeRequiredToStudy;
            GroupId = groupId;
            SubGroupId = subGroupId;
            DateRelease = dateRelease;
            IsSpecial = isSpecial;
            IsActive = isActive;
            ImageFile = imageFile;
        }

        public Guid AuthorId { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }
        public string Description { get; private set; }
        public string ImageAlt { get; private set; }
        public string Tags { get; private set; }
        public int TimeRequiredToStudy { get; private set; }
        public long GroupId { get; private set; }
        public long? SubGroupId { get; private set; }
        public string DateRelease { get; private set; }
        public bool IsSpecial { get; private set; }
        public bool IsActive { get; private set; }
        public IFormFile ImageFile { get; private set; }
    }

  
}