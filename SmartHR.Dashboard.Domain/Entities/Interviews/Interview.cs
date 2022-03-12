using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SmartHR.Dashboard.Domain.Entities.Users;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Domain.Entities.Interviews
{
    public class Interview : BaseEntity
    {
        public long InterviewerId { get; set; }
        
        [ForeignKey(nameof(InterviewerId))]
        public User Interviewer { get; }

        public long ApplicantId { get; set; }
        
        [ForeignKey(nameof(ApplicantId))]
        public User Applicant { get; }

        public DateTime ScheduleDate { get; set; }
        public string Description { get; set; }
        public InterviewStatus Status { get; set; }
    }
}
