namespace SmartHR.Dashboard.Domain.Models.Payme
{
    public class PaymeRequest
    {
        /// <summary>
        /// Method name of payme billing
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Paramaters of request / user
        /// </summary>
        public RequestParams Params { get; set; }

        /// <summary>
        /// Request of id
        /// </summary>
        public int Id { get; set; }
    }
}
