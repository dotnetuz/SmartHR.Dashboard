using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using SmartHR.Dashboard.Data.Contexts;
using SmartHR.Dashboard.Data.IRepositories;
using System;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Data.Repositories
{
#pragma warning disable
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartHRDbContext _smartHRDbContext;
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        /// <summary>
        /// Repositories
        /// </summary>
        public IUserRepository Users { get; private set; }
        public IUserAuthRepository UserAuths { get; private set; }

        public IInterviewRepository Interviews { get; private set; }
        public ITechnologyRepository Technologies { get; private set; }

        public UnitOfWork(SmartHRDbContext smartHRDbContext, IConfiguration config)
        {
            _smartHRDbContext = smartHRDbContext;
            _config = config;

            // Setting up logging service
            _logger = new LoggerConfiguration()
                .WriteTo.File
                (
                    path: "Logs/logs.txt",
                    outputTemplate: config.GetSection("Serilog").GetSection("OutputTemplate").Value,
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information
                ).CreateLogger();

            // Initialize repositories
            Users = new UserRepository(_smartHRDbContext, _logger);
            UserAuths = new UserAuthRepository(_smartHRDbContext, _logger);
            Interviews = new InterviewRepository(_smartHRDbContext, _logger);
            Technologies = new TechnologyRepository(_smartHRDbContext, _logger);
        }

        public async Task CompleteTaskAsync()
        {
            await _smartHRDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _smartHRDbContext.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
