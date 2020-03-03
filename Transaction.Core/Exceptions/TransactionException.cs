using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Core.Types;

namespace Transaction.Core.Exceptions
{
    public abstract class TransactionException : Exception
    {
        public abstract int ErrorCode { get; }

        public TransactionException(string message) : base(message)
        {

        }
    }

    public class InsufficientBalanceException : TransactionException
    {
        public override int ErrorCode =>
                TransactionErrorCode.InsufficientBalance;

        public InsufficientBalanceException()
            : base($"This operation cannot be performed due to insufficient funds in the account")
        { }
    }

    public class InvalidAccountNumberException : TransactionException
    {
        public override int ErrorCode => TransactionErrorCode.AccountDoesNotExistError;
        public InvalidAccountNumberException(int accountNumber) : base($"This account {accountNumber} does not exist.")
        {

        }
    }

    public class InvalidAmountException : TransactionException
    {
        public override int ErrorCode => TransactionErrorCode.InvalidAmount;

        public InvalidAmountException(decimal amount) : base($"This operation cannot be performed for {amount} amount.")
        {

        }
    }

    public class InvalidCurrencyException : TransactionException
    {
        public override int ErrorCode => TransactionErrorCode.InvalidCurrencyError;

        public InvalidCurrencyException(string currency) : base($"This operation cannot be performed with {currency} currency.")
        {

        }
    }

    public class CurrencyMismatchException : TransactionException
    {
        public override int ErrorCode => TransactionErrorCode.CurrencyMismatchError;
        public CurrencyMismatchException(Currency c1, Currency c2) : base($"This operation cannot be performed between {c1} and {c2}")
        {

        }
    }

}
