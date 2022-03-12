using System;

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
