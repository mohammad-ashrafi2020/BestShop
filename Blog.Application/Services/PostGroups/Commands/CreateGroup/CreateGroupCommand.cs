using System;
using Blog.Application.Common;

namespace Blog.Application.Services.PostGroups.Commands.CreateGroup
{
    public class CreateGroupCommand : IBaseRequest, ICommitTableRequest
    {
        public CreateGroupCommand(string groupTitle, string englishGroupTitle, string metaDescription, long? parentId)
        {
            GroupTitle = groupTitle;
            EnglishGroupTitle = englishGroupTitle;
            MetaDescription = metaDescription;
            ParentId = parentId;
        }

        public string GroupTitle { get; private set; }
        public string EnglishGroupTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public long? ParentId { get; private set; }
    }
}