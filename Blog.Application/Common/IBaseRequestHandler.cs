using AutoMapper;
using Blog.Infrastructure.Persistent.EF.Context;
using framework;
using MediatR;

namespace Blog.Application.Common
{
    internal interface IBaseRequestHandler<TCommand> : IRequestHandler<TCommand, OperationResult> where TCommand : IRequest<OperationResult>
    {
        public BlogContext _Context { get; }
        public IMapper _Mapper { get; }
    }
    internal interface IBaseRequestHandler<TCommand,TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
    {
        public BlogContext _Context { get; }
        public IMapper _Mapper { get; }
    }
}