using System;

namespace SmartHR.Dashboard.Domain.Models.Payme.Results
{
    public class PerformTransactionResult
    {
        public long? Transaction { get; set; }
        public DateTime? PerformDate { get; set; }
        public int? State { get; set; }
    }
}
