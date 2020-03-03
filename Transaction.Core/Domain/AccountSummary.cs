using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Core.Types;

namespace Transaction.Core.Domain
{
    public class AccountSummary
    {
        public int AccountNumber { get; set; }

        public Money Balance { get; set; }
    }
}
