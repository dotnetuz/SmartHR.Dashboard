using SmartHR.Dashboard.Domain.Models.Payme;
using SmartHR.Dashboard.Domain.Models.Payme.Entities;
using SmartHR.Dashboard.Domain.Models.Payme.Enums;
using SmartHR.Dashboard.Domain.Models.Payme.Results;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Interfaces
{
    public interface IPaymeService
    {
        Task<PaymeResponse<CheckPerformTransactionResult>> CheckPerformTransactionAsync(int amount, Account account);

        Task<PaymeResponse<CreateTransactionResult>> CreateTransactionAsync(string id, double time, int amount, Account account);

        Task<PaymeResponse<PerformTransactionResult>> PerformTransactionAsync(string id);

        Task<PaymeResponse<CancelTransactionResult>> CancelTransactionAsync(string id, OrderCancelReason reason);

        Task<PaymeResponse<CheckTransactionResult>> CheckTransactionAsync(string id);

        Task<PaymeResponse<Transactions>> GetStatementAsync(double from, double to);

        Task<PaymeResponse<ChangePasswordResult>> ChangePasswordAsync(string password);

        Task<dynamic> PerformAsync(PaymeRequest request);

    }
}
