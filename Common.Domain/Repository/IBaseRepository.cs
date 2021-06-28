using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Domain.Repository
{
    public interface IBaseRepository<TKey, T> where T : class
    {
        Task<T> Get(TKey id);
        Task<T> GetTracking(TKey id);
        Task Create(T entity);
        Task AddRange(ICollection<T> entities);
        void Update(T entity);
        Task<int> Save();
        Task<bool> Exists(Expression<Func<T, bool>> expression);
    }
}