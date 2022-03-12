using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<User>> CreateAsync(User user);
        Task<BaseResponse<string>> LoginAsync(string username, string password);
        Task<BaseResponse<CollectionResult<User>>> GetAllAsync(int pageSize, int pageIndex, Expression<Func<User, bool>> predicate = null);
        Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> predicate);
    }
}
