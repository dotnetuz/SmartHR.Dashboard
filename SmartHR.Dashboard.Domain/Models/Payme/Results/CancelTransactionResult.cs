using System;

namespace SmartHR.Dashboard.Domain.Models.Payme.Results
{
    public class CancelTransactionResult
    {
        public long? Transaction { get; set; }
        public DateTime? CancelTime { get; set; }
        public int? State { get; set; }
    }
}
