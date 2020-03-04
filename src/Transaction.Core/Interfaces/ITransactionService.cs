using System.Threading.Tasks;
using Transaction.Core.Domain;

namespace Transaction.Core.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionResult> Balance(int accountNumber);

        Task<TransactionResult> Deposit(AccountTransaction accountTransaction);

        Task<TransactionResult> Withdraw(AccountTransaction accountTransaction);
    }
}
