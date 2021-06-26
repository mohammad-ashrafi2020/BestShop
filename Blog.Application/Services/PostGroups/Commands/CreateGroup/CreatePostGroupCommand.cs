using Common.Application;

namespace Blog.Application.Services.PostGroups.Commands.CreateGroup
{
    public class CreatePostGroupCommand : IBaseRequest, ICommitTableRequest
    {
        public CreatePostGroupCommand(string groupTitle, string englishGroupTitle, string metaDescription, long? parentId)
        {
            GroupTitle = groupTitle;
            EnglishGroupTitle = englishGroupTitle.ToLower();
            MetaDescription = metaDescription;
            ParentId = parentId;
        }

        public string GroupTitle { get; private set; }
        public string EnglishGroupTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public long? ParentId { get; private set; }
    }
}