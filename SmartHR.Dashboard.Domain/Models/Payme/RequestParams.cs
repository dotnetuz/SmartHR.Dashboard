using SmartHR.Dashboard.Domain.Models.Payme.Entities;
using SmartHR.Dashboard.Domain.Models.Payme.Enums;

namespace SmartHR.Dashboard.Domain.Models.Payme
{
    public class RequestParams
    {
        public string Id { get; set; }
        public double Time { get; set; }
        public int Amount { get; set; }
        public Account Account { get; set; }
        public OrderCancelReason Reason { get; set; }
        public double From { get; set; }
        public double To { get; set; }
    }
}
