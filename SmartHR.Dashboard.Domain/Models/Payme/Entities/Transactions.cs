using System.Collections.Generic;
using SmartHR.Dashboard.Domain.Models.Payme.Results;

namespace SmartHR.Dashboard.Domain.Models.Payme.Entities
{
    public class Transactions
    {
        public IList<GetStatementResult> Transactionss { get; set; }
    }
}
