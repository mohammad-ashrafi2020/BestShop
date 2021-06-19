using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using _DomainUtils.Domain;
using _DomainUtils.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.EF.Context;

namespace Shop.Infrastructure.EF.Repository
{
    public abstract class BaseRepository<TKey, T> : IBaseRepository<TKey, T> where T : BaseEntity<TKey>
    {
        protected readonly ShopContext Context;

        protected BaseRepository(ShopContext context)
        {
            Context = context;
        }


        public virtual async Task<T> Get(TKey id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
        }

        public async Task Create(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().AnyAsync(expression);
        }
    }
}