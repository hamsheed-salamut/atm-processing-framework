using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction.Core.Entities;
using Transaction.Core.Interfaces;
using Transaction.Infrastructure.Persistence;

namespace Transaction.Infrastructure.Repositories
{
    public class AccountSummaryRepository : IAccountSummaryRepository
    {
        private readonly TransactionDbContext _dbContext;
        private readonly DbSet<AccountSummaryEntity> _accountSummaryEntity;

        public AccountSummaryRepository(TransactionDbContext dbContext)
        {
            _dbContext = dbContext;
            _accountSummaryEntity = _dbContext.Set<AccountSummaryEntity>();
        }

        public async Task<AccountSummaryEntity> Read(int accountNumber)
        {
            return await _accountSummaryEntity.AsNoTracking()
                .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }
    }
}
