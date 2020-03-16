using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Core.Entities;
using Transaction.Infrastructure.EntityConfigurations;

namespace Transaction.Infrastructure.Persistence
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AccountSummaryEntityConfiguration.Configure(modelBuilder.Entity<AccountSummaryEntity>());

            AccountTransactionEntityConfiguration.Configure(modelBuilder.Entity<AccountTransactionEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
