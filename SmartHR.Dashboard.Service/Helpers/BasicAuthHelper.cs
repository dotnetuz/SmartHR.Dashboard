using System;
using System.Linq;
using System.Text;

namespace SmartHR.Dashboard.Service.Helpers
{
    public class BasicAuthHelper
    {
        public static (string username, string password) GetCredentials(string authHeader)
        {
            string encoded = authHeader.Replace("Basic ", "").Trim();

            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string[] credentials = encoding.GetString(Convert.FromBase64String(encoded)).Split(':');

            return (credentials[0], credentials[1]);
        }
    }
}