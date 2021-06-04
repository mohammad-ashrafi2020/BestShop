using Blog.Application.Common;

namespace Blog.Application.Services.Posts.Commands.ToggleStatus
{
    public record ToggleBlogPostCommand(long PostId) : IBaseRequest, ICommitTableRequest;

}