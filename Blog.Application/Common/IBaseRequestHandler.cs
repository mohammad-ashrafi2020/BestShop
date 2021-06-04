using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using MediatR;

namespace Blog.Application.Common
{
    internal interface IBaseRequestHandler<TCommand> : IRequestHandler<TCommand, OperationResult> where TCommand : IRequest<OperationResult>
    {
    }
    internal interface IBaseRequestHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
    {
    }
}