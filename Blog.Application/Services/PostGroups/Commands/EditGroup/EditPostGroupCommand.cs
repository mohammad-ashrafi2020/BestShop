using Blog.Application.Common;

namespace Blog.Application.Services.PostGroups.Commands.EditGroup
{
    public class EditPostGroupCommand : IBaseRequest, ICommitTableRequest
    {
        public EditPostGroupCommand(long id,  string metaDescription, string englishGroupTitle, string groupTitle)
        {
            Id = id;
            MetaDescription = metaDescription;
            EnglishGroupTitle = englishGroupTitle.ToLower();
            GroupTitle = groupTitle;
        }

        public long Id { get; private set; }
        public string GroupTitle { get; private set; }
        public string EnglishGroupTitle { get; private set; }
        public string MetaDescription { get; private set; }
    }
}