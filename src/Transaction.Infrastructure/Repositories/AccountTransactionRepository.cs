using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction.Core.Entities;
using Transaction.Core.Exceptions;
using Transaction.Core.Interfaces;
using Transaction.Core.Types;
using Transaction.Infrastructure.Persistence;

namespace Transaction.Infrastructure.Repositories
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        private readonly TransactionDbContext _dbContext;
        private readonly DbSet<AccountSummaryEntity> _accountSummaryEntity;
        private readonly DbSet<AccountTransactionEntity> _accountTransactionEntity;

        public AccountTransactionRepository(TransactionDbContext dbContext)
        {
            _dbContext = dbContext;
            _accountSummaryEntity = _dbContext.Set<AccountSummaryEntity>();
            _accountTransactionEntity = _dbContext.Set<AccountTransactionEntity>();
        }

        public async Task Create(AccountTransactionEntity accountTransactionEntity, AccountSummaryEntity accountSummaryEntity)
        {
            _accountTransactionEntity.Add(accountTransactionEntity);
            _accountSummaryEntity.Add(accountSummaryEntity);

            bool isSaved = false;

            while (!isSaved)
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    isSaved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is AccountSummaryEntity)
                        {
                            var databaseValues = entry.GetDatabaseValues();

                            if (databaseValues != null)
                            {
                                entry.OriginalValues.SetValues(databaseValues);
                                CalculateNewBalance();

                                void CalculateNewBalance()
                                {
                                    var balance = (decimal)entry.OriginalValues["Balance"];
                                    var amount = accountTransactionEntity.Amount;

                                    if (accountTransactionEntity.TransactionType == TransactionType.Deposit.ToString())
                                    {
                                        accountSummaryEntity.Balance = balance += amount;
                                    }
                                    else if (accountTransactionEntity.TransactionType == TransactionType.Withdrawal.ToString())
                                    {
                                        if (amount > balance)
                                            throw new InsufficientBalanceException();

                                        accountSummaryEntity.Balance = balance -= amount;
                                    }
                                }
                            }
                            else
                            {
                                throw new NotSupportedException();
                            }
                        }
                    }
                }
            }
        }
    }
}
