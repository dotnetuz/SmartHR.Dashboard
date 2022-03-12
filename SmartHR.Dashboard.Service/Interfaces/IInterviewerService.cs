using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using SmartHR.Dashboard.Domain.Enums;
using SmartHR.Dashboard.Service.ViewModels.Interviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface IInterviewerService
    {
        ValueTask<BaseResponse<CollectionResult<Interview>>> GetRequestsAsync(int pageSize, int pageIndex, InterviewStatus status);
        ValueTask<BaseResponse<Interview>> UpdateStatusAsync(UpdateInterviewStatusViewModel updateModel);
    }
}
