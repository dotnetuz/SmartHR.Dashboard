using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Data.IRepositories
{
    public interface IGenericRepository<TSource> where TSource : class
    {
        Task<IQueryable<TSource>> GetAllAsync(Expression<Func<TSource, bool>> expression = null);
        Task<TSource> GetAsync(Expression<Func<TSource, bool>> expression);
        Task<bool> DeleteAsync(Expression<Func<TSource, bool>> expression);
        Task<TSource> UpdateAsync(TSource entity);
        Task<TSource> CreateAsync(TSource entity);
    }
}
