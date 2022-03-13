using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.Users;
using SmartHR.Dashboard.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHR.Dashboard.Domain.Entities.Interviews
{
    public class Interview : BaseEntity
    {
        public long InterviewerId { get; set; }

        [ForeignKey(nameof(InterviewerId))]
        public User Interviewer { get; set; }

        public long ApplicantId { get; set; }

        [ForeignKey(nameof(ApplicantId))]
        public User Applicant { get; set; }

        public DateTime ScheduleDate { get; set; }
        public string Description { get; set; }
        public InterviewStatus Status { get; set; } = InterviewStatus.Pending;
    }
}
