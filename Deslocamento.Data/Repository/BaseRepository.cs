using ApiDeslocamento.Data.Context;
using ApiDeslocamento.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly ApplicationDbContext _applicationDbContext;

        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = applicationDbContext.Set<T>();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : T
        {
            _dbSet.Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : T
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate); 
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id).ConfigureAwait(false);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : T
        {
            _dbSet.Update(entity);
        }
    }
}