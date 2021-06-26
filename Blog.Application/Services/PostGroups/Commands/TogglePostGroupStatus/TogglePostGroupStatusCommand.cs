using Common.Application;

namespace Blog.Application.Services.PostGroups.Commands.TogglePostGroupStatus
{
    public record TogglePostGroupStatusCommand(long GroupId) : IBaseRequest, ICommitTableRequest;
}
