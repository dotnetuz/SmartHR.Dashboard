using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.ViewModels.Interviews
{
    public class InterviewViewModel
    {
        public long InterviewerId { get; set; }
        public long ApplicantId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string Description { get; set; }
    }
}
