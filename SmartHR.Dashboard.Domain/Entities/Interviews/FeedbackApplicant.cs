using SmartHR.Dashboard.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHR.Dashboard.Domain.Entities.Interviews
{
    public class FeedbackApplicant : BaseEntity
    {
        [ForeignKey(nameof(InterviewId))]
        public Interview Interview { get; }

        public long InterviewId { get; }

        public string Feedback { get; set; }
    }
}
