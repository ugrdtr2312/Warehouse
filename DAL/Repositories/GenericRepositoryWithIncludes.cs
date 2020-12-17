using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Extensions;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class GenericRepositoryWithIncludes<T> : IRepository<T> where T : BaseEntity
    {
        protected DbSet<T> DbSet { get; }

        protected GenericRepositoryWithIncludes(DbContext context)
        {
            DbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await DbSetWithAllProperties().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await DbSetWithAllProperties()
                .AsNoTracking()
                .ToListAsync();
            
            return entities;
        }

        public async Task<IEnumerable<T>> FindAsync(Func<T, Task<bool>> predicate)
        {
            var entity = await DbSetWithAllProperties().AsNoTracking().WhereAsync(predicate);
            
            return entity;
        }

        public async Task CreateAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task<IEnumerable<T>> GetWithIncludesAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            return await IncludeProperties(includeProperties).ToListAsync();
        }

        protected abstract IQueryable<T> DbSetWithAllProperties();

        private IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbSet;

            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);
            
            return query;
        }
 
    }
}