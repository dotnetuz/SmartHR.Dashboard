using Microsoft.EntityFrameworkCore;
using Serilog;
using SmartHR.Dashboard.Data.Contexts;
using SmartHR.Dashboard.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Data.Repositories
{
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

        public async Task<TSource> DeleteAsync(Expression<Func<TSource, bool>> expression)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(expression);
                if (entity is not null)
                    return null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in delete method");
                throw;
            }
        }

        public Task<IQueryable<TSource>> GetAllAsync(Expression<Func<TSource, bool>> expression = null)
        {
            try
            {

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

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in get method");
                throw;
            }
        }

        public Task<TSource> UpdateAsync(TSource entity)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in update method");
                throw;
            }
        }
    }
}
