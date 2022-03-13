using System;
using SmartHR.Dashboard.Domain.Models.Payme.Enums;

namespace SmartHR.Dashboard.Domain.Models.Payme.Entities
{
    public class OrderTransaction
    {
        public long Id { get; set; }
        public string PaycomeId { get; set; }
        public DateTime PaycomTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? PerformTime { get; set; }
        public DateTime? CancelTime { get; set; }
        public OrderCancelReason? Reason { get; set; }
        public TransactionState State { get; set; }
        public CustomerOrder Order { get; set; }
    }
}
