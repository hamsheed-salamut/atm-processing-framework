using System;
using System.Collections.Generic;
using System.Text;

namespace Transaction.Core.Entities
{
    public class AccountTransactionEntity
    {
        public int TransactionId { get; set; }

        public int AccountNumber { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string TransactionType { get; set; }

        public decimal Amount { get; set; }

        public AccountSummaryEntity AccountSummary { get; set; }
    }
}
