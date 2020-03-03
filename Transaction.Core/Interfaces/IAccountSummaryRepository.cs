using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction.Core.Entities;

namespace Transaction.Core.Interfaces
{
    public interface IAccountSummaryRepository
    {
        Task<AccountSummaryEntity> Read(int accountNumber);
    }
}
