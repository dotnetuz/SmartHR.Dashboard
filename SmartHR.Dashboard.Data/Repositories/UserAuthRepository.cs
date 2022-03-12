using Serilog;
using SmartHR.Dashboard.Data.Contexts;
using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Entities.Users;

namespace SmartHR.Dashboard.Data.Repositories
{
    public class UserAuthRepository : GenericRepository<UserAuth>, IUserAuthRepository
    {
        public UserAuthRepository(SmartHRDbContext smartHRDbContext, ILogger logger) : base(smartHRDbContext, logger)
        {
        }
    }
}
