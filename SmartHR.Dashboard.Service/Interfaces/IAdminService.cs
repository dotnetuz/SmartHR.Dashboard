using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface IAdminService
    {
        Task CompleteRegistrationAsync(IList<long> userIdentities, bool isApproved = true);
    }
}
