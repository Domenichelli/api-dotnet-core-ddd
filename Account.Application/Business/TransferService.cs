using Account.Interface.Infra;
using Account.Interface.Business;
using System;
using Account.Domain.Response;
using Account.Domain.Entities;
using Account.Domain.Converters;
using Account.Domain.Contracts;
using System.Collections.Generic;

namespace Account.Application.Business
{
    public class TransferService : ITransferServiceRepository
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountServiceRepository accountServiceRepository;
        private readonly IClientRepository clientRepository;
        private readonly ITransferRepository transferRepository;

        public TransferService(IAccountRepository _accountRepository, IClientRepository _clientRepository, IAccountServiceRepository _accountServiceRepository, ITransferRepository _transferRepository)
        {
            accountRepository = _accountRepository;
            clientRepository = _clientRepository;
            accountServiceRepository = _accountServiceRepository;
            transferRepository = _transferRepository;
        }

        public bool GetHasBalance(Guid AccountID, decimal value)
        {
            return accountRepository.GetAccountByAccountID(AccountID).Balance > value;
        }

        public ResultGeneric<PostTransfersResponse> Transfer(PostTransferAccountRequest request)
        {
            var result = new ResultGeneric<PostTransfersResponse>();
            result.Success = false;

            if(!accountServiceRepository.GetAccountHasBlocked(request.AccountIDfrom))
            {
                if(!accountServiceRepository.GetAccountHasBlocked(request.AccountIDto))
                {
                    if(GetHasBalance(request.AccountIDfrom, request.value))
                    {
                        #region AccountFrom
                        var accountTransferFrom = TransferConverter.Parse(request);
                        accountTransferFrom.TypeTransaction = Domain.Enums.ETypeTransaction.Debit;
                        accountTransferFrom.TypePay = Domain.Enums.ETypePay.Bank;

                        transferRepository.Insert(accountTransferFrom);
                        this.Withdraw(request.AccountIDfrom, request.value);
                        #endregion

                        #region AccountTo
                        var accountTransferTo = TransferConverter.Parse(request);
                        accountTransferTo.TypeTransaction = Domain.Enums.ETypeTransaction.Credit;
                        accountTransferTo.TypePay = Domain.Enums.ETypePay.Bank;
                        

                        transferRepository.Insert(accountTransferTo);
                        this.Deposit(request.AccountIDto, request.value);

                        #endregion
                        result.Data = TransferConverter.Parse(accountTransferFrom);

                        result.Success = true;
                    }
                    else
                    {
                        result.Errors.Add("Conta de origem não possui saldo sulficiente");
                    }
                }
                else
                {
                    result.Errors.Add("Conta de destino está bloqueada, solicite o desbloquei se possivel!");
                }
            }
            else
            {
                result.Errors.Add("Conta de origem está bloqueada, solicite o desbloquei se possivel!");
            }

            return result;
        }

        private ResultGeneric<AccountEntity> Deposit(Guid accountID, decimal value)
        {
            var result = new ResultGeneric<AccountEntity>();

            var account = accountRepository.GetAccountByAccountID(accountID);
            account.Balance = account.Balance + value;
            accountRepository.Update(account);

            result.Data = account;
            result.Success = true;

            return result;
        }

        private ResultGeneric<AccountEntity> Withdraw(Guid accountID, decimal value)
        {
            var result = new ResultGeneric<AccountEntity>();

            var account = accountRepository.GetAccountByAccountID(accountID);
            account.Balance = account.Balance - value;
            accountRepository.Update(account);

            result.Data = account;
            result.Success = true;

            return result;
        }

        public ResultGeneric<PostTransfersResponse> DepositAccount(Guid accountID, decimal value)
        {
            var result = new ResultGeneric<PostTransfersResponse>();

            if (!accountServiceRepository.GetAccountHasBlocked(accountID))
            {
                var accountTransferTo = TransferConverter.Parse(accountID, value);
                accountTransferTo.TypeTransaction = Domain.Enums.ETypeTransaction.Credit;
                accountTransferTo.TypePay = Domain.Enums.ETypePay.Money;

                transferRepository.Insert(accountTransferTo);
                this.Deposit(accountID, value);

                result.Data = TransferConverter.Parse(accountTransferTo);
                result.Success = true;
            }
            else
            {
                result.Errors.Add("Conta de destino está bloqueada, solicite o desbloquei se possivel!");
            }

            return result;
        }

        public ResultGeneric<GetExtractResponse> GetExtract(Guid accountID)
        {
            var result = new ResultGeneric<GetExtractResponse>();
            
            var data = new GetExtractResponse();
            data.balance = accountRepository.GetAccountByAccountID(accountID).Balance;
            data.Transfer = new List<TransferHistory>();

            var list = transferRepository.GetAllTransfersAccount(accountID);
            foreach(var item in list)
            {
                if(item.TypeTransaction == Domain.Enums.ETypeTransaction.Credit && item.AccountIDfrom.Equals(accountID) ||
                    item.TypeTransaction == Domain.Enums.ETypeTransaction.Debit && item.AccountIDto.Equals(accountID))
                {
                    continue;
                }
                else
                {
                    data.Transfer.Add(TransferConverter.ParseHistory(item));
                }
            }

            result.Data = data;
            result.Success = true;
            return result;
        }

    }
}
