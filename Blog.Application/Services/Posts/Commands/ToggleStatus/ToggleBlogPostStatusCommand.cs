using Blog.Application.Common;

namespace Blog.Application.Services.Posts.Commands.ToggleStatus
{
    public record ToggleBlogPostStatusCommand(long PostId) : IBaseRequest, ICommitTableRequest;

}