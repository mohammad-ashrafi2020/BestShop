using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Entities.BlogPostAggregate;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Common.Domain.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;

namespace Blog.Domain.Entities.BlogPostGroupAggregate
{
    public class BlogPostGroup : BaseEntity<long>
    {
        public string GroupTitle { get; private set; }
        public string EnglishGroupTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public long? ParentId { get; private set; }

        [ForeignKey("ParentId")]
        public ICollection<BlogPostGroup> Groups { get; set; }
        public ICollection<BlogPost> MainBlogPosts { get; set; }
        public ICollection<BlogPost> SubBlogPosts { get; set; }

        //For Ef
        private BlogPostGroup()
        {
            Groups = new List<BlogPostGroup>();
        }
        public BlogPostGroup(string englishGroupTitle, string groupTitle, string metaDescription, IEnglishTitleUniquenessChecker checker)
        {
            if (string.IsNullOrWhiteSpace(groupTitle))
                throw new InvalidDomainDataException("عنوان گروه اجباری است");

            if (string.IsNullOrWhiteSpace(englishGroupTitle))
                throw new InvalidDomainDataException("عنوان انگلیسی اجباری است");

            if (string.IsNullOrWhiteSpace(metaDescription))
                throw new InvalidDomainDataException("Meta Description Is Required");

            if (!checker.IsUnique(englishGroupTitle.Trim().ToLower()))
                throw new InvalidDomainDataException("عنوان انگلیسی تکراری است");

            if (englishGroupTitle.Domain_IsUniCode())
                throw new InvalidDomainDataException("عنوان انگلیسی فقط باید شامل حرف انگلیسی باشد");

            EnglishGroupTitle = englishGroupTitle.Trim().ToLower();
            GroupTitle = groupTitle;
            MetaDescription = metaDescription;
            ParentId = null;
            Groups = new List<BlogPostGroup>();
        }

        public void Edit(string englishGroupTitle, string groupTitle, string metaDescription, IEnglishTitleUniquenessChecker checker)
        {
            if (string.IsNullOrWhiteSpace(groupTitle))
                throw new InvalidDomainDataException("عنوان گروه اجباری است");

            if (string.IsNullOrWhiteSpace(englishGroupTitle))
                throw new InvalidDomainDataException("عنوان انگلیسی اجباری است");

            if (string.IsNullOrWhiteSpace(metaDescription))
                throw new InvalidDomainDataException("Meta Description Is Required");

            if (englishGroupTitle.Domain_IsUniCode())
                throw new InvalidDomainDataException("عنوان انگلیسی فقط باید شامل حرف انگلیسی باشد");

            if (EnglishGroupTitle != englishGroupTitle.Trim().ToLower())
                if (!checker.IsUnique(englishGroupTitle))
                    throw new InvalidDomainDataException("عنوان انگلیسی تکراری است");

           

            EnglishGroupTitle = englishGroupTitle.Trim().ToLower();
            GroupTitle = groupTitle;
            MetaDescription = metaDescription;
            ModifyDate = DateTime.Now;
        }

        public void AddChild(string englishGroupTitle, string groupTitle, string metaDescription, IEnglishTitleUniquenessChecker checker)
        {
            var group = new BlogPostGroup(englishGroupTitle, groupTitle, metaDescription, checker)
            {
                ParentId = Id
            };
            Groups.Add(group);
        }
    }
}