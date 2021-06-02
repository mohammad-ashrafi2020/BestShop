using Blog.Application.Common;

namespace Blog.Application.Services.PostGroups.Commands.DeleteGroup
{
    public class DeletePostGroupCommand : IBaseRequest, ICommitTableRequest
    {
        public DeletePostGroupCommand(long groupId)
        {
            GroupId = groupId;
        }

        public long GroupId { get; private set; }
    }
}