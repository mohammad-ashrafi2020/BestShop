﻿using System;
using System.Collections.Generic;
using _DomainUtils.Domain;
using _DomainUtils.Exceptions;
using Blog.Domain.Entities.BlogPostAggregate;

namespace Blog.Domain.Entities.BlogPostGroupAggregate
{
    public class BlogPostGroup:BaseEntity<long>
    {
        public string GroupTitle { get; private set; }
        public string EnglishGroupTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public long? ParentId { get; private set; }

        public ICollection<BlogPostGroup> Groups { get; set; }
        public ICollection<BlogPost> MainBlogPosts { get; set; }
        public ICollection<BlogPost> SubBlogPosts { get; set; }


        public BlogPostGroup(string englishGroupTitle, string groupTitle, string metaDescription, long? parentId)
        {
            if (string.IsNullOrWhiteSpace(groupTitle))
                throw new InvalidDomainDataException("عنوان گروه اجباری است");

            if (string.IsNullOrWhiteSpace(englishGroupTitle))
                throw new InvalidDomainDataException("عنوان انگلیسی اجباری است");

            if (string.IsNullOrWhiteSpace(metaDescription))
                throw new InvalidDomainDataException("Meta Description Is Required");

            EnglishGroupTitle = englishGroupTitle.Trim().ToLower();
            GroupTitle = groupTitle;
            MetaDescription = metaDescription;
            ParentId = parentId;
        }

        public void Edit(string englishGroupTitle, string groupTitle, string metaDescription, long? parentId)
        {
            if (string.IsNullOrWhiteSpace(groupTitle))
                throw new InvalidDomainDataException("عنوان گروه اجباری است");

            EnglishGroupTitle = englishGroupTitle.Trim().ToLower();
            GroupTitle = groupTitle;
            MetaDescription = metaDescription;
            ParentId = parentId;
            ModifyDate=DateTime.Now;
        }
    }
}