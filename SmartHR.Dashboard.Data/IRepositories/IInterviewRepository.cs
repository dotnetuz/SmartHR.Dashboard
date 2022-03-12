using SmartHR.Dashboard.Domain.Entities.Interviews;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Data.IRepositories
{
    public interface IInterviewRepository : IGenericRepository<Interview>
    {
        Task<FeedbackApplicant> LeaveFeedbackAsync(FeedbackApplicant feedback);
    }
}
