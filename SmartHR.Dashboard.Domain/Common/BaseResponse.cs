namespace SmartHR.Dashboard.Domain.Common
{
    public class BaseResponse<TSource>
    {
        public BaseResponse()
        {

        }
        public BaseResponse(TSource data, ErrorModel error = null)
        {
            Data = data;
            Error = error;
        }
        public TSource Data { get; set; }
        public ErrorModel Error { get; set; }
    }
}
