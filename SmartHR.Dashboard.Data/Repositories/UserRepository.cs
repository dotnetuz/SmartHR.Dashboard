using Serilog;
using SmartHR.Dashboard.Data.Contexts;
using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Entities.Users;

namespace SmartHR.Dashboard.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SmartHRDbContext smartHRDbContext, ILogger logger) : base(smartHRDbContext, logger)
        {
        }
    }
}
