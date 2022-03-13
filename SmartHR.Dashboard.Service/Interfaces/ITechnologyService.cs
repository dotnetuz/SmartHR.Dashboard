using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.Users;
using SmartHR.Dashboard.Service.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface ITechnologyService
    {
        Task<BaseResponse<Technology>> CreateAsync(TechnologyViewModel technology);
        Task<BaseResponse<CollectionResult<Technology>>> GetAllAsync(int pageSize, int pageIndex, Expression<Func<User, bool>> predicate = null);
        Task<BaseResponse<Technology>> GetAsync(Expression<Func<Technology, bool>> predicate);
    }
}
