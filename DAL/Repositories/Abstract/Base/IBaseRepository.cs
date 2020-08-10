using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IndexViewModel<TEntity>> GetAllAsync(string searchFilter, int pageSize, int pageNumber = 1);
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveRangeAsync(IEnumerable<TEntity> range);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        void Remove(TEntity entity);
    }
}
