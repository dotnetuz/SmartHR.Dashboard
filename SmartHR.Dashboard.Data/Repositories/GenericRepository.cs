using Microsoft.EntityFrameworkCore;
using Serilog;
using SmartHR.Dashboard.Data.Contexts;
using SmartHR.Dashboard.Data.IRepositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Data.Repositories
{
#pragma warning disable
    public class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : class
    {
        private readonly ILogger _logger;
        internal SmartHRDbContext _smartHRDbContext;
        internal DbSet<TSource> _dbSet;
        public GenericRepository(SmartHRDbContext smartHRDbContext, ILogger logger)
        {
            _smartHRDbContext = smartHRDbContext;
            _dbSet = _smartHRDbContext.Set<TSource>();
            _logger = logger;
        }

        public async Task<TSource> CreateAsync(TSource entity)
        {
            try
            {
                var entry = await _dbSet.AddAsync(entity);

                return entry.Entity;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in create method");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<TSource, bool>> expression)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(expression);
                if (entity is null)
                    return false;

                _dbSet.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in delete method");
                throw;
            }
        }

        public async Task<IQueryable<TSource>> GetAllAsync(Expression<Func<TSource, bool>> expression = null)
        {
            try
            {
                return _dbSet;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in get all method");
                throw;
            }
        }

        public Task<TSource> GetAsync(Expression<Func<TSource, bool>> expression)
        {
            try
            {
                return _dbSet.FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in get method");
                throw;
            }
        }

        public async Task<TSource> UpdateAsync(TSource entity)
        {
            try
            {
                return _dbSet.Update(entity).Entity;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in update method");
                throw;
            }
        }
    }
}
