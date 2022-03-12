using SmartHR.Dashboard.Service.ViewModels;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface IMailService
    {
        ValueTask SendEmailAsync(MailRequest mailRequest);
    }
}
