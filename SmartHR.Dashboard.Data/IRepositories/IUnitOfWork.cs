using System;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IUserAuthRepository UserAuths { get; }
        IInterviewRepository Interviews { get; }

        ITechnologyRepository Technologies { get; }
        Task CompleteTaskAsync();
    }
}
