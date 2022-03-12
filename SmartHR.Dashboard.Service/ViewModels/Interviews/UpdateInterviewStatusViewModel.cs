using SmartHR.Dashboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.ViewModels.Interviews
{
    public class UpdateInterviewStatusViewModel
    {
        public long Id { get; set; }
        public InterviewStatus Status { get; set; } = InterviewStatus.Pending;
    }
}
