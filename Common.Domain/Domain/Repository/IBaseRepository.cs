﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Domain.Domain.Repository
{
    public interface IBaseRepository<TKey, T> where T : class
    {
        Task<T> Get(TKey id);
        Task Create(T entity);
        void Update(T entity);
        Task<int> Save();
        Task<bool> Exists(Expression<Func<T, bool>> expression);
    }
}