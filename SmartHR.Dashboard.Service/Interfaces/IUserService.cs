using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.Users;
using SmartHR.Dashboard.Service.ViewModels.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<User>> CreateAsync(UserViewModel user);
        Task<BaseResponse<object>> LoginAsync(string username, string password);
        Task<BaseResponse<CollectionResult<User>>> GetAllAsync(int pageSize, int pageIndex, Expression<Func<User, bool>> predicate = null);
        Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> predicate);
    }
}
