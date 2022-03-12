using Microsoft.AspNetCore.Http;
using System.Linq;

namespace SmartHR.Dashboard.Service.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor;
        public static HttpContext Context => Accessor.HttpContext;
        public static string Language => Context?.Request?.Headers?.FirstOrDefault(p => p.Key == "Language").Value;
        public static long? UserId => long.Parse(Context?.User?.FindFirst("UserId")?.Value);
    }
}
