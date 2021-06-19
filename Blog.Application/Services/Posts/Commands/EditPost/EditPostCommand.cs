using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.Posts.Commands.EditPost
{
    public class EditPostCommand : IBaseRequest
    {
        public EditPostCommand(string title, string urlTitle, string metaDescription, string description, string imageAlt, string tags, int timeRequiredToStudy, long groupId, long? subGroupId, string dateRelease, bool isSpecial, bool isActive, IFormFile imageFile, long id)
        {
            Title = title;
            UrlTitle = urlTitle;
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
            Id = id;
        }

        public long Id { get; private set; }
        public string Title { get; private set; }
        public string UrlTitle { get; private set; }
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