using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactManager.Domain.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity FindById(int id);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        long Count();
        long Count(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] properties);
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties);

        // ASYNC
        Task<TEntity> FindByIdAsync(int id);
        Task<IQueryable<TEntity>> GetAsync();
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<long> CountAsync();
        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] properties);
        Task<IQueryable<TEntity>> GetWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties);

        void Create(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);

        Task CreateAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task RemoveAsync(TEntity item);
    }
}
