using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Core.Entities;

namespace Transaction.Infrastructure.EntityConfigurations
{
    public static class AccountSummaryEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AccountSummaryEntity> entityBuilder)
        {
            entityBuilder.HasKey(t => t.AccountNumber);
            entityBuilder.Property(t => t.Balance).IsConcurrencyToken().IsRequired();
            entityBuilder.Property(t => t.Currency).IsRequired();
        }
    }
}
