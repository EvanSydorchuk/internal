using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Abstract;
using PagedList;

namespace DAL.Repositories
{
    abstract public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        protected BaseRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.BulkInsertAsync(entities, options => options.IncludeGraph = true);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.Where(expression).ToListAsync();
        }

        public virtual async Task<IndexViewModel<TEntity>> GetAllAsync(string searchFilter, int pageSize, int pageNumber = 1)
        {
            var stringProperties = typeof(TEntity).GetProperties()
                .Where(prop => prop.PropertyType == searchFilter.GetType());

            var filteredItems = _entities.Where((customer => stringProperties.Any(prop => prop.GetValue(customer, null) == searchFilter)));
            var result = await filteredItems.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var pageViewModel = new PageViewModel(_entities.Count(), pageNumber, pageSize);

            var viewModel = new IndexViewModel<TEntity>
            {
                PageViewModel = pageViewModel,
                Data = result
            };

            return viewModel;
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> range)
        {
             await _entities.BulkDeleteAsync(range, options => options.IncludeGraph = true);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.SingleOrDefaultAsync(expression);
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}
