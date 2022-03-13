namespace SmartHR.Dashboard.Domain.Models.Payme
{
    public class PaymeErrorModel
    {
        public PaymeErrorModel(int? code = null, object message = null, object data = null)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }
        public int? Code { get; set; }
        public object Message { get; set; }
        public object Data { get; set; }
    }
}