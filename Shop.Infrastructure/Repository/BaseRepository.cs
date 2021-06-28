using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Repository;
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

        public async Task<T> GetTracking(TKey id)
        {
            return await Context.Set<T>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;

        }

        public async Task Create(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(ICollection<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public async Task ToggleStatus(TKey id)
        {
            var entity =await GetTracking(id);
            if (entity.IsDelete)
                entity.Recovery();
            else
                entity.Delete();
            Update(entity);
        }

        public  void Update(T entity)
        {
            Context.Update(entity);
        }

        public async Task<int> Save()
        {
            return await Context.SaveChangesAsync();
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().AnyAsync(expression);
        }
    }
}