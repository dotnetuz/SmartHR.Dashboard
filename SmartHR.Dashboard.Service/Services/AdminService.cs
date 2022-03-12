using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Enums;
using SmartHR.Dashboard.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CompleteRegistrationAsync(IList<long> userIdentities, bool isApproved = true)
        {
            foreach (var identity in userIdentities)
            {
                var user = await this.unitOfWork.Users.GetAsync(user => user.Id == identity);

                user.State = isApproved ? ItemState.Approved : ItemState.Rejected;
            }
             
            await this.unitOfWork.CompleteTaskAsync();
        }
    }
}
