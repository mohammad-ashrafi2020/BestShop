using Blog.Application.Common;

namespace Blog.Application.Services.PostGroups.Commands.EditGroup
{
    public class EditPostGroupCommand : IBaseRequest, ICommitTableRequest
    {
        public EditPostGroupCommand(long id, long? parentId, string metaDescription, string englishGroupTitle, string groupTitle)
        {
            Id = id;
            ParentId = parentId;
            MetaDescription = metaDescription;
            EnglishGroupTitle = englishGroupTitle.ToLower();
            GroupTitle = groupTitle;
        }

        public long Id { get; private set; }
        public string GroupTitle { get; private set; }
        public string EnglishGroupTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public long? ParentId { get; private set; }
    }
}