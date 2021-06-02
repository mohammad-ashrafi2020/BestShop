using System;
using System.Collections.Generic;
using _DomainUtils.Domain;
using Blog.Domain.Entities.BlogPostGroupAggregate;

namespace Blog.Domain.Entities.BlogPostAggregate
{
    public class BlogPost : BaseEntity
    {
        public Guid AuthorId { get; private set; }
        public string Title { get; private set; }
        public string UrlTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public string Description { get; private set; }
        public string ImageName { get; private set; }
        public string ImageAlt { get; private set; }
        public string Tags { get; private set; }
        public string ShortLink { get; private set; }
        public int TimeRequiredToStudy { get; private set; }
        public Guid GroupId { get; private set; }
        public Guid? SubGroupId { get; private set; }
        public long Visit { get; private set; }
        public DateTime DateRelease { get; private set; }
        public bool IsSpecial { get; private set; }

        #region Relation
        public BlogPostGroup Group { get; set; }
        public BlogPostGroup SubGroup { get; set; }

        #endregion



        public BlogPost(Guid authorId, string title, string metaDescription, string urlTitle, string description,
            string imageName, string imageAlt, string tags, string shortLink, int timeRequiredToStudy,
            Guid groupId, Guid? subGroupId, DateTime dateRelease, bool isSpecial)
        {
            AuthorId = authorId;
            Title = title;
            MetaDescription = metaDescription;
            UrlTitle = urlTitle;
            Description = description;
            ImageName = imageName;
            ImageAlt = imageAlt;
            Tags = tags;
            ShortLink = shortLink;
            TimeRequiredToStudy = timeRequiredToStudy;
            GroupId = groupId;
            SubGroupId = subGroupId;
            Visit = 0;
            DateRelease = dateRelease;
            IsSpecial = isSpecial;
        }

        public void Edit(string tags, string title, string metaDescription, string urlTitle, string description,
            string imageName, string imageAlt, string shortLink, int timeRequiredToStudy,
            Guid groupId, Guid? subGroupId, DateTime dateRelease, bool isSpecial)
        {
            ModifyDate = DateTime.Now;
            Tags = tags;
            Title = title;
            MetaDescription = metaDescription;
            UrlTitle = urlTitle;
            Description = description;
            ImageName = imageName;
            ImageAlt = imageAlt;
            ShortLink = shortLink;
            TimeRequiredToStudy = timeRequiredToStudy;
            GroupId = groupId;
            SubGroupId = subGroupId;
            Visit = 0;
            DateRelease = dateRelease;
            IsSpecial = isSpecial;
        }

        public void IncreaseVisitor()
        {
            Visit += 1;
        }
    }
}