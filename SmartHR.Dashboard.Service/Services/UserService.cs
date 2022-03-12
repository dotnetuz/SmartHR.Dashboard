using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.User;
using SmartHR.Dashboard.Service.Extensions;
using SmartHR.Dashboard.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<User>> CreateAsync(User user)
        {
            var response = new BaseResponse<User>();
            var newUser = await _unitOfWork.Users.CreateAsync(user);
            if(newUser is null)
            {
                response.Error = new ErrorModel(404, "User is exist");
                return response;
            }

            await _unitOfWork.CompleteTaskAsync();

            response.Data = newUser;
            return response;
        }

        public async Task<BaseResponse<CollectionResult<User>>> GetAllAsync(int pageSize, int pageIndex, Expression<Func<User, bool>> predicate = null)
        {
            var response = new BaseResponse<CollectionResult<User>>();

            IQueryable<User> users = await _unitOfWork.Users.GetAllAsync(predicate);

            response.Data = new CollectionResult<User>(users.Count(), users.ToPagination(pageSize, pageIndex));

            return response;
        }

        public async Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> predicate)
        {
            var response = new BaseResponse<User>();

            var user = await _unitOfWork.Users.GetAsync(predicate);
            if(user is null)
            {
                response.Error = new ErrorModel(404, "User not found");
                return response;
            }

            response.Data = user;

            return response;
        }

        public async Task<BaseResponse<User>> LoginAsync(string username, string password)
        {
            var response = new BaseResponse<User>();

            var user = await GetAsync(p => p.Username == username && p.Password == password);
            if(user is null)
            {
                response.Error = new ErrorModel(404, "User not found");
                return response;
            }

            return user;
        }
    }
}
