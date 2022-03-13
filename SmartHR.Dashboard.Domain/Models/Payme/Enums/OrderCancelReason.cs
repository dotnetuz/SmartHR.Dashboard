namespace SmartHR.Dashboard.Domain.Models.Payme.Enums
{
    public enum OrderCancelReason
    {
        REVEIVER_NOT_FOUND = 1,
        DEBIT_OPERATION_ERROR = 2,
        TRANSACTION_ERROR = 3,
        TRANSACTION_TIMEOUT = 4,
        MONEY_BACK = 5,
        UNKNOWN_ERROR = 10
    }
}
