using ContactManager.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Domain.Concrete
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public long Count()
        {
            return _dbSet.LongCount();
        }

        public long Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.LongCount(predicate);
        }

        public IQueryable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] properties)
        {
            return Include(properties);
        }

        public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties)
        {
            var query = Include(properties);
            return query.Where(predicate);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IQueryable<TEntity>> GetAsync()
        {
            return await Task.Run(() => _dbSet.AsNoTracking());
        }

        public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _dbSet.AsNoTracking().Where(predicate));
        }

        public async Task<long> CountAsync()
        {
            return await _dbSet.LongCountAsync();
        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.LongCountAsync(predicate);
        }

        public async Task<IQueryable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] properties)
        {
            return await IncludeAsync(properties);
        }

        public async Task<IQueryable<TEntity>> GetWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties)
        {
            var query = await IncludeAsync(properties);
            return await Task.Run(() => query.Where(predicate));
        }

        // Для загрузки связанных данных
        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] properties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return properties.Aggregate(query, (current, property) => current.Include(property));
        }

        // Для загрузки связанных данных
        private async Task<IQueryable<TEntity>> IncludeAsync(params Expression<Func<TEntity, object>>[] properties)
        {
            IQueryable<TEntity> query = await Task.Run(() => _dbSet.AsNoTracking());
            return properties.Aggregate(query, (current, property) => current.Include(property));
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public async Task CreateAsync(TEntity item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
