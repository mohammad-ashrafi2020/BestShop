using System;
using Blog.Application.Common;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IBaseRequest, ICommitTableRequest
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string ImageAlt { get; set; }
        public string Tags { get; set; }
        public int TimeRequiredToStudy { get; set; }
        public Guid GroupId { get; set; }
        public Guid? SubGroupId { get; set; }
        public string DateRelease { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsActive { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}