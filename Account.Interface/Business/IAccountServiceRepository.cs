using Account.Domain.Contracts;
using Account.Domain.Entities;
using Account.Domain.Response;
using System;
using System.Collections.Generic;

namespace Account.Interface.Business
{
    public interface IAccountServiceRepository
    {
        ResultGeneric<PostClientAccountResponse> Register(PostClientAccountRequest entity);
        ResultGeneric<List<GetAccountsResponse>> GetAccountsByDocument(string cpf);
        ResultGeneric<string> LockAccount(PutBloquedAccountRequest request);
        bool GetAccountHasBlocked(Guid AccountID);

    }
}
