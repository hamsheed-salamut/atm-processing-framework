using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Core.Types;

namespace Transaction.Core.Domain
{
    public class TransactionResult
    {
        public int AccountNumber { get; set; }

        public bool IsSuccessful { get; set; }

        public Money Balance { get; set; }

        public string Message { get; set; }
    }
}
