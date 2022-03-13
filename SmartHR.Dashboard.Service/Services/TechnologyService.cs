using AutoMapper;
using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.Users;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TechnologyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Technology>> CreateAsync(TechnologyViewModel technologyViewModel)
        {
            var response = new BaseResponse<Technology>();

            var technology = this.mapper.Map<Technology>(technologyViewModel);

            var newTechnology = await this.unitOfWork.Technologies.CreateAsync(technology);

            await this.unitOfWork.CompleteTaskAsync();

            response.Data = newTechnology;

            return response;
        }

        public Task<BaseResponse<CollectionResult<Technology>>> GetAllAsync(int pageSize, int pageIndex, Expression<Func<User, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Technology>> GetAsync(Expression<Func<Technology, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
