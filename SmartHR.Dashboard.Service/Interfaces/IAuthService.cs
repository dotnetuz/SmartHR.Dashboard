using SmartHR.Dashboard.Domain.Entities.Users;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(string key, string issuer, User user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
