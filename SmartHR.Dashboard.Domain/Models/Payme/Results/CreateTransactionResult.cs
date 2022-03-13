using System;

namespace SmartHR.Dashboard.Domain.Models.Payme.Results
{
    public class CreateTransactionResult
    {
        public DateTime? CreateTime { get; set; }
        public long? Transaction { get; set; }
        public int? State { get; set; }
    }
}
