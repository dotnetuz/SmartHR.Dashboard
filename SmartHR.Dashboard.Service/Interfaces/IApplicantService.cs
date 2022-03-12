using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using SmartHR.Dashboard.Service.ViewModels.Interviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface IApplicantService
    {
        Task<BaseResponse<Interview>> SendRequestAsync(InterviewViewModel interview);
    }
}
