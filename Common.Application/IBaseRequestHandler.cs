using framework;
using MediatR;

namespace Common.Application
{
    public interface IBaseRequestHandler<TCommand> : IRequestHandler<TCommand, OperationResult> where TCommand : IRequest<OperationResult>
    {
    }
    public interface IBaseRequestHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
    {
    }
}