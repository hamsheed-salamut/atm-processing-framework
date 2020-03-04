using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction.Core.Domain;
using Transaction.Core.Entities;
using Transaction.Core.Extensions;
using Transaction.Core.Interfaces;
using Transaction.Core.Types;
using Transaction.Core.Validations;

namespace Transaction.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAccountSummaryRepository _accountSummaryRepository;
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public TransactionService(IAccountSummaryRepository accountSummaryRepository, IAccountTransactionRepository accountTransactionRepository, ILogger<TransactionService> logger, IMapper mapper)
        {
            _accountSummaryRepository = accountSummaryRepository ?? throw new ArgumentNullException(nameof(accountSummaryRepository));
            _accountTransactionRepository = accountTransactionRepository ?? throw new ArgumentNullException(nameof(accountTransactionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TransactionResult> Balance(int accountNumber)
        {
            var accountSummary = await GetAccountSummary(accountNumber);
            await accountSummary.Validate(accountNumber);

            return _mapper.Map<TransactionResult>(accountSummary);
        }

        public async Task<TransactionResult> Deposit(AccountTransaction accountTransaction)
        {
            _logger.LogInformation(LoggingEvents.Deposit, " account transaction:{0}", JsonConvert.SerializeObject(accountTransaction));

            Guard.ArgumentNotNull(nameof(accountTransaction), accountTransaction);

            var accountNumber = accountTransaction.AccountNumber;
            var accountSummary = await GetAccountSummary(accountNumber);

            await accountSummary.Validate(accountNumber);
            await accountTransaction.Validate(accountSummary);

            var balance = accountSummary.Balance;
            var amount = accountTransaction.Amount;

            accountSummary.Balance = balance -= amount;

            var transactionResult = await CreateTransactionAndUpdateSummary(accountTransaction, accountSummary);

            _logger.LogInformation(LoggingEvents.Deposit, " account transaction:{0}", JsonConvert.SerializeObject(transactionResult));

            return transactionResult;
        }

        public async Task<TransactionResult> Withdraw(AccountTransaction accountTransaction)
        {
            _logger.LogInformation(LoggingEvents.Withdrawal, " account trnasaction:{0}", JsonConvert.SerializeObject(accountTransaction));

            Guard.ArgumentNotNull(nameof(accountTransaction), accountTransaction);

            var accountNumber = accountTransaction.AccountNumber;
            var accountSummary = await GetAccountSummary(accountNumber);

            await accountSummary.Validate(accountNumber);
            await accountTransaction.Validate(accountSummary);

            var balance = accountSummary.Balance;
            var amount = accountTransaction.Amount;

            accountSummary.Balance = balance -= amount;

            var transactionResult = await CreateTransactionAndUpdateSummary(accountTransaction, accountSummary);

            _logger.LogInformation(LoggingEvents.Withdrawal, " transaction result:{0}", JsonConvert.SerializeObject(transactionResult));

            return transactionResult;

        }

        #region private helpers
        private async Task<AccountSummary> GetAccountSummary(int accountNumber)
        {
            var accountSummaryEntity = await _accountSummaryRepository
                .Read(accountNumber);

            return _mapper.Map<AccountSummary>(accountSummaryEntity);
        }

        private async Task<TransactionResult> CreateTransactionAndUpdateSummary(AccountTransaction accountTransaction, AccountSummary accountSummary)
        {
            var accountTransactionEntity = _mapper.Map<AccountTransactionEntity>(accountTransaction);
            var accountSummaryEntity = _mapper.Map<AccountSummaryEntity>(accountSummary);

            await _accountTransactionRepository.Create(accountTransactionEntity, accountSummaryEntity);
            var currentSummary = await _accountSummaryRepository.Read(accountTransaction.AccountNumber);

            var result = _mapper.Map<TransactionResult>(accountTransactionEntity);

            result.Balance = new Money(currentSummary.Balance, currentSummary.Currency.TryParseEnum<Currency>());

            return result;

        }
        #endregion
    }
}
