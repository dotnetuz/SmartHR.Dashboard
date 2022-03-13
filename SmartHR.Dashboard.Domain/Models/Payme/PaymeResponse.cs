namespace SmartHR.Dashboard.Domain.Models.Payme
{
    public class PaymeResponse<TResponse>
    {
        public TResponse Result { get; set; }
        public PaymeErrorModel Error { get; set; }
        public int Id { get; set; }
    }

}