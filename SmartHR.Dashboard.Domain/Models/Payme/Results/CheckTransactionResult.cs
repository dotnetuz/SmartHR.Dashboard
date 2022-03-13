using System;

namespace SmartHR.Dashboard.Domain.Models.Payme.Results
{
    public class CheckTransactionResult
    {
        public DateTime? CreateTime { get; set; }
        public DateTime? PerformTime { get; set; }
        public DateTime? CancelTime { get; set; }
        public long? Transaction { get; set; }
        public int? State { get; set; }
        public int? Reason { get; set; }
    }
}
