using Common.Core.Enums;

namespace Common.Application
{
    public interface IBaseQueryFilter<T> : MediatR.IRequest<T>
    {
        public SearchOn SearchOn { get; set; }
    }
}