using Blog.Application.Common;

namespace Blog.Application.Services.Posts.Commands.ToggleStatus
{
    public record TogglePostStatusCommand(long PostId) : IBaseRequest, ICommitTableRequest;

}