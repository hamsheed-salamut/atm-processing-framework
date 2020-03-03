using System;
using System.Collections.Generic;
using System.Text;

namespace Transaction.Core.Entities
{
    public class AccountSummaryEntity
    {
        public int AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public string Currency { get; set; }

        public ICollection<AccountTransactionEntity> AccountTransactions { get; set; }
    }
}
