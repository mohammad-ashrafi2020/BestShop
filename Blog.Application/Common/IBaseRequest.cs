using framework;
using MediatR;

namespace Blog.Application.Common
{
    internal interface IBaseRequest : IRequest<OperationResult>
    {

    }

    internal interface IBaseRequest<T> : IRequest<T>
    {

    }
}