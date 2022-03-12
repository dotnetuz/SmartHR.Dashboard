using SmartHR.Dashboard.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(string key, string issuer, User user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
