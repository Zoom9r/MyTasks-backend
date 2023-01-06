using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyTasksDataBase.Repositories.Interfaces.Base;
using System.Linq.Expressions;

namespace MyTasksDataBase.Repositories.Realizations.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MyTasksDBContext MyTasksDBContext { get; set; }

        public RepositoryBase(MyTasksDBContext context)
        {
            MyTasksDBContext = context;
        }

        public void Create(T entity)
        {
            MyTasksDBContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            MyTasksDBContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = MyTasksDBContext.Set<T>().AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (include != null)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetFisrtOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = MyTasksDBContext.Set<T>().AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (include != null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            MyTasksDBContext.Set<T>().Update(entity);
        }
    }
}
