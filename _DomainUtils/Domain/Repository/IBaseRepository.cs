using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _DomainUtils.Domain.Repository
{
    public interface IBaseRepository<TKey, T> where T : class
    {
        Task<T> Get(TKey id);
        Task Create(T entity);
        Task<bool> Exists(Expression<Func<T, bool>> expression);
    }
}