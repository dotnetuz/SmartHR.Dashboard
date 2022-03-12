using Serilog;
using Serilog.Core;
using SmartHR.Dashboard.Data.Contexts;
using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using System;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Data.Repositories
{
    public class InterviewRepository : GenericRepository<Interview>, IInterviewRepository
    {
        public InterviewRepository(SmartHRDbContext smartHRDbContext, ILogger logger) : base(smartHRDbContext, logger)
        {
        }

        public async Task<FeedbackApplicant> LeaveFeedbackAsync(FeedbackApplicant feedback)
        {
            try
            {
                var entry = await _smartHRDbContext.FeedbackApplicants.AddAsync(feedback);

                return entry.Entity;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in create method");
                throw;
            }
        }
    }
}
