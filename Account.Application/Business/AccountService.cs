using Account.Domain.Contracts;
using Account.Domain.Converters;
using Account.Domain.Entities;
using Account.Domain.Response;
using Account.Interface.Business;
using Account.Interface.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Application.Business
{
    public class AccountService : IAccountServiceRepository
    {
        private readonly IAccountRepository accountRepository;
        private readonly IClientRepository clientRepository;

        public AccountService(IAccountRepository _accountRepository, IClientRepository _clientRepository)
        {
            accountRepository = _accountRepository;
            clientRepository = _clientRepository;
        }

        public ResultGeneric<PostClientAccountResponse> Register(PostClientAccountRequest entity)
        {
            var accountCreate = new ResultGeneric<PostClientAccountResponse>();

            var newClient = ClientConverter.Parse(entity);
            var newAccount = AccountConverter.Parse(entity);
            var clientID = new Guid();

            #region Client
            var client = clientRepository.getByDocument(entity.CPF);
            if(client != null)
            {
                clientID = client.ClientID;
            }
            else
            {
                clientRepository.Insert(newClient);
                clientID = newClient.ClientID;
            }
            #endregion

            #region Account

            if(!accountRepository.AccountExists(entity.AgencyNumber, entity.AccountNumber))
            {
                newAccount.ClientID = clientID;
                accountRepository.Insert(newAccount);

                accountCreate.Success = true;
            }
            else
            {
                accountCreate.Success = false;
                accountCreate.Errors.Add("Conta já existente");
            }

            accountCreate.Data = ClientConverter.Parse(newClient, newAccount);
            #endregion

            return accountCreate;
        }

        public ResultGeneric<List<GetAccountsResponse>> GetAccountsByDocument(string cpf)
        {
            var result = new ResultGeneric<List<GetAccountsResponse>>();
            var client = clientRepository.getByDocument(cpf);

            if(client != null)
            {
                var accounts = accountRepository.GetAllAccountsByClientID(client.ClientID);

                if (accounts.Count > 0)
                {
                    var retorno = new List<GetAccountsResponse>();
                    accounts.ForEach(a => retorno.Add(AccountConverter.Parse(a, cpf)));

                    result.Data = retorno;
                    result.Success = true;
                }
                else
                {
                    result.Success = false; ;
                    result.Errors.Add("Nenhuma conta localizada");
                }
            }
            else
            {
                result.Success = false; ;
                result.Errors.Add("Cliente não localizado com o CPF: " + cpf);
            }

            return result;
        }

        public ResultGeneric<string> LockAccount(PutBloquedAccountRequest request)
        {
            var result = new ResultGeneric<string>();
            result.Success = false;

            var account = accountRepository.GetAccountByAccountID(request.AccountID);
            if(account != null)
            {
                if(account.Bloqued == request.Block)
                {
                    result.Errors.Add("Conta já está: " + (account.Bloqued ? "Bloqueada" : "Desbloqueada"));
                }
                else
                {
                    result.Success = true;
                    account.Bloqued = request.Block;
                    accountRepository.Update(account);
                }
            }
            else
            {
                result.Errors.Add("Conta não localizada");
            }
            
            return result;
        }

        public bool GetAccountHasBlocked(Guid accountID)
        {
            return accountRepository.GetAccountByAccountID(accountID).Bloqued;
        }
    }
}
