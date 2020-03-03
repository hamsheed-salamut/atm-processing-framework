using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Core.Types;

namespace Transaction.Core.Domain
{
    public class AccountTransaction
    {
        public int AccountNumber { get; set; }

        public TransactionType TransactionType { get; set; }

        public Money Amount { get; set; }
    }
}
