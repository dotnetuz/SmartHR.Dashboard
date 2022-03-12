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

        public UnitOfWork(SmartHRDbContext smartHRDbContext, ILogger logger, IConfiguration config)
        {
            _smartHRDbContext = smartHRDbContext;
            _logger = logger;
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
            Users = new UserRepository(_smartHRDbContext, logger);
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
