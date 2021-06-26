using MediatR;

namespace Common.Application
{
    public interface IBaseRequest : IRequest<OperationResult>
    {

    }

    public interface IBaseRequest<T> : IRequest<T>
    {

    }
}