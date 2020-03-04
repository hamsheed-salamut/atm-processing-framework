using System;
using System.Collections.Generic;
using System.Text;

namespace Transaction.Core.Extensions
{
    public static class StringExtension
    {
        public static TEnum TryParseEnum<TEnum>(this string item) where TEnum : struct
        {
            return Enum.TryParse(item, true, out TEnum tEnumResult) ? tEnumResult : default(TEnum);
        }
    }
}
