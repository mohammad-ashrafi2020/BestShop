using System;
using Blog.Domain.Entities.BlogPostAggregate.Rules;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Common.Domain.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;

namespace Blog.Domain.Entities.BlogPostAggregate
{
    public class BlogPost : BaseEntity<long>
    {
        public Guid AuthorId { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }
        public string Description { get; private set; }
        public string ImageName { get; private set; }
        public string ImageAlt { get; private set; }
        public string Tags { get; private set; }
        public string ShortLink { get; private set; }
        public int TimeRequiredToStudy { get; private set; }
        public long GroupId { get; private set; }
        public long? SubGroupId { get; private set; }
        public long Visit { get; private set; }
        public DateTime DateRelease { get; private set; }
        public bool IsSpecial { get; private set; }

        #region Relation
        public BlogPostGroup Group { get; set; }
        public BlogPostGroup SubGroup { get; set; }

        #endregion

        private BlogPost()
        {
            //For Ef
        }
        public BlogPost(Guid authorId, string title, string metaDescription, string slug, string description,
            string imageName, string imageAlt, string tags, string shortLink, int timeRequiredToStudy,
            long groupId, long? subGroupId, DateTime dateRelease, bool isSpecial, IPostSlugUniquenessChecker _slugChecker)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
                throw new InvalidDomainDataException("Title And Description Is Required");

            if (!_slugChecker.IsUniq(slug.Domain_ToSlug()))
                throw new InvalidDomainDataException("عنوان انگلیسی تکراری است");

            AuthorId = authorId;
            Title = title;
            MetaDescription = metaDescription;
            Slug = slug.Domain_ToSlug();
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

        public void Edit(string tags, string title, string metaDescription, string slug, string description,
            string imageName, string imageAlt, int timeRequiredToStudy,
            long groupId, long? subGroupId, DateTime dateRelease, bool isSpecial, IPostSlugUniquenessChecker _slugChecker)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
                throw new InvalidDomainDataException("Title And Description Is Required");

            if (Slug != slug.Domain_ToSlug())
                if (!_slugChecker.IsUniq(slug.Domain_ToSlug()))
                    throw new InvalidDomainDataException("عنوان انگلیسی تکراری است");


            ModifyDate = DateTime.Now;
            Tags = tags;
            Title = title;
            MetaDescription = metaDescription;
            Slug = slug;
            Description = description;
            ImageName = imageName;
            ImageAlt = imageAlt;
            TimeRequiredToStudy = timeRequiredToStudy;
            GroupId = groupId;
            SubGroupId = subGroupId;
            Visit = 0;
            DateRelease = dateRelease;
            IsSpecial = isSpecial;
        }

        public void IncreaseVisit()
        {
            Visit += 1;
        }
    }
}