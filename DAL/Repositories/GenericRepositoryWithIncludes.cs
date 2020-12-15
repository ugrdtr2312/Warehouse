using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Exceptions;
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

            if (entity == null)
            {
                throw new DbRecordNotFoundException("Record with parameter not found exception", id.ToString());
            }

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

            if (entity == null)
            {
                throw new DbRecordNotFoundException("Records with parameter not found exception", "entities");
            }

            return entity;
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
                throw new RepositoryArgumentNullException("Error in repository with entity while executing create", "entity");

            await DbSet.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null)
                throw new RepositoryArgumentNullException("Error in repository with entity while executing remove", "entity");
            
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new RepositoryArgumentNullException("Error in repository with entity while executing update", "entity");

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
            {
                if (includeProperty == null)
                        throw new IncludePropertyNullException("Include property is null");

                query = query.Include(includeProperty);
            }

            return query;
        }
 
    }
}