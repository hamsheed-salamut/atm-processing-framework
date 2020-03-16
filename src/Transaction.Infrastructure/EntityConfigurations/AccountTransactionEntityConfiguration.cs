using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Core.Entities;

namespace Transaction.Infrastructure.EntityConfigurations
{
    public static class AccountTransactionEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AccountTransactionEntity> entityBuilder)
        {
            entityBuilder.HasKey(t => t.TransactionId);
            entityBuilder.HasOne(u => u.AccountSummary).WithMany(e => e.AccountTransactions).HasForeignKey(u => u.AccountNumber);
            entityBuilder.Property(t => t.Date).IsRequired();
            entityBuilder.Property(t => t.Description).IsRequired();
            entityBuilder.Property(t => t.TransactionType).IsRequired();
            entityBuilder.Property(t => t.Amount).IsRequired();
        }
    }
}
