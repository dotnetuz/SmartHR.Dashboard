using AutoMapper;
using Microsoft.Extensions.Configuration;
using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.Users;
using SmartHR.Dashboard.Domain.Enums;
using SmartHR.Dashboard.Service.Extensions;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.ViewModels.Users;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IAuthService authService, IConfiguration config, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
            _config = config;
            _mapper = mapper;
        }

        public async Task<BaseResponse<User>> CreateAsync(UserViewModel user)
        {
            var response = new BaseResponse<User>();

            var mapped = _mapper.Map<User>(user);
            var newUser = await _unitOfWork.Users.CreateAsync(mapped);
            if (newUser is null)
            {
                response.Error = new ErrorModel(404, "User is exist");
                return response;
            }

            var userAuth = await _unitOfWork.UserAuths.GetAsync(p => p.UserId == newUser.Id);
            if (userAuth is null)
            {
                await _unitOfWork.UserAuths.CreateAsync(new UserAuth
                {
                    UserId = newUser.Id,
                });
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
            if (user is null)
            {
                response.Error = new ErrorModel(404, "User not found");
                return response;
            }

            response.Data = user;

            return response;
        }

        public async Task<BaseResponse<object>> LoginAsync(string username, string password)
        {
            var response = new BaseResponse<object>();

            var user = await _unitOfWork.Users.GetAsync(p => p.Username == username &&
                p.State != ItemState.Deleted);

            if (user is null)
            {
                response.Error = new ErrorModel(400, "Username or password is incorrect");
                return response;
            }

            if (user.Username == username && user.Password == password)
            {
                string token = _authService.CreateToken(_config["Jwt:Key"], _config["Jwt:Issuer"], user);

                var userAuth = await _unitOfWork.UserAuths.GetAsync(p => p.UserId == user.Id);
                if (userAuth is not null)
                {
                    userAuth.Token = token;
                    userAuth.LastLoginDate = DateTime.Now;
                    user.UpdatedDate = DateTime.Now;
                }
                else
                {
                    await _unitOfWork.UserAuths.CreateAsync(new UserAuth
                    {
                        UserId = user.Id,
                        Token = token,
                        LastLoginDate = DateTime.Now,
                    });
                }

                await _unitOfWork.CompleteTaskAsync();

                response.Data = new
                {
                    user = user,
                    token = token
                };

                return response;
            }

            response.Error = new ErrorModel(400, "Username or password is incorrect");

            return response;
        }
    }
}
