namespace SmartHR.Dashboard.Domain.Models.Payme.Entities
{
    public class CustomerOrder
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public bool Delivered { get; set; }
    }
}