using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Models.Payme;
using SmartHR.Dashboard.Domain.Models.Payme.Entities;
using SmartHR.Dashboard.Domain.Models.Payme.Enums;
using SmartHR.Dashboard.Domain.Models.Payme.Results;
using SmartHR.Dashboard.Service.Interfaces;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace SmartHR.Dashboard.Service.Services
{
#pragma warning disable
    public class PaymeService : IPaymeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaymeResponse<CancelTransactionResult>> CancelTransactionAsync(string id, OrderCancelReason reason)
        {
            // get/set data from/to database

            return new PaymeResponse<CancelTransactionResult>
            {
                Error = new PaymeErrorModel
                {
                    Code = -32504,
                    Message = "Проблема"
                }
            };
        }

        public async Task<PaymeResponse<ChangePasswordResult>> ChangePasswordAsync(string password)
        {
            return new PaymeResponse<ChangePasswordResult>
            {
                Result = new ChangePasswordResult
                {
                    Success = true
                }
            };
        }

        public async Task<PaymeResponse<CheckPerformTransactionResult>> CheckPerformTransactionAsync(int amount, Account account)
        {
            var order = await _unitOfWork.Users.GetAsync(p => p.Phone == account.Phone);

            // get/set data from/to database

            return new PaymeResponse<CheckPerformTransactionResult>
            {
                Result = new CheckPerformTransactionResult
                {
                    Allow = true,
                },
                Error = new PaymeErrorModel
                {
                    Code = -32504,
                    Message = "Nimadriasasdasd"
                }
            };
        }

        public async Task<PaymeResponse<CheckTransactionResult>> CheckTransactionAsync(string id)
        {
            // get/set data from/to database

            return new PaymeResponse<CheckTransactionResult>
            {
                Error = new PaymeErrorModel
                {
                    Code = -32504,
                    Message = "Проблема"
                }
            };
        }

        public async Task<PaymeResponse<CreateTransactionResult>> CreateTransactionAsync(string id, double time, int amount, Account account)
        {
            // create transaction
            if ((await CheckPerformTransactionAsync(amount, account)).Result.Allow)
            {
                // get/set data from/to database

                return new PaymeResponse<CreateTransactionResult>
                {
                    Result = new CreateTransactionResult
                    {
                        CreateTime = DateTime.Now,
                        State = 1,
                        Transaction = long.Parse(id)
                    },
                    Error = new PaymeErrorModel
                    {
                        Code = -32504,
                        Message = "Transaksiya ochildi"
                    }
                };
            }

            return new PaymeResponse<CreateTransactionResult>
            {
                Error = new PaymeErrorModel
                {
                    Code = -32504,
                    Message = "Amalga oshirilmadi"
                }
            };
        }

        public async Task<PaymeResponse<Transactions>> GetStatementAsync(double from, double to)
        {
            return new PaymeResponse<Transactions>
            {
                Error = new PaymeErrorModel
                {
                    Code = -32504,
                    Message = "asdasdasd"
                }
            };
        }

        public async Task<dynamic> PerformAsync(PaymeRequest request)
        {
            switch (request.Method)
            {
                case "CheckPerformTransaction":
                    return await CheckPerformTransactionAsync(request.Params.Amount, request.Params.Account);
                case "CheckTransaction":
                    return await CheckTransactionAsync(request.Params.Id);
                case "CreateTransaction":
                    return await CreateTransactionAsync(request.Params.Id, request.Params.Time, request.Params.Amount, request.Params.Account);
                case "PerformTransaction":
                    return await PerformTransactionAsync(request.Params.Id);
                case "CancelTransaction":
                    return await CancelTransactionAsync(request.Params.Id, request.Params.Reason);
                case "GetStatement":
                    return await GetStatementAsync(request.Params.From, request.Params.To);
                default:
                    return new PaymeResponse<object>
                    {
                        Error = new PaymeErrorModel
                        {
                            Code = -32504,
                            Message = "Method not found",
                            Data = "Method"
                        }
                    };
            }
        }

        public async Task<PaymeResponse<PerformTransactionResult>> PerformTransactionAsync(string id)
        {
            // get/set data from/to database

            return new PaymeResponse<PerformTransactionResult>
            {
                Error = new PaymeErrorModel
                {
                    Code = -32504,
                    Message = "Проблема"
                }
            };
        }
    }
}
