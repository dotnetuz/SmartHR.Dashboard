using System;
using SmartHR.Dashboard.Domain.Models.Payme.Entities;

namespace SmartHR.Dashboard.Domain.Models.Payme.Results
{
#nullable enable
    public class GetStatementResult
    {
        public string? Id { get; set; }
        public DateTime? TIme { get; set; }
        public int? Amount { get; set; }
        public Account? Account { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? PerformTime { get; set; }
        public DateTime? CancelTime { get; set; }
        public long? Transaction { get; set; }
        public int? State { get; set; }
        public int? Reason { get; set; }
    }
}
