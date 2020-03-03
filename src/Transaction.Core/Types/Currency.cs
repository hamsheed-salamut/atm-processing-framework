using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Transaction.Core.Types
{
    public enum Currency
    {
        Unknown = 0,

        [Description("United States Dollar")]
        USD = 840,

        [Description("Pound Sterling")]
        GBP = 826,

        [Description("Euro")]
        EUR = 978, 

        [Description("Indian Rupee")]
        INR = 356
    }
}
