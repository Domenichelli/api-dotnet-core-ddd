using Account.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Account.Interface.Infra
{
    public interface IAccountRepository : IRepository<AccountEntity>
    {
        bool AccountExists(string agency, string account);

        List<AccountEntity> GetAllAccountsByClientID(Guid clientID);

        AccountEntity GetAccountByAccountID(Guid accountID);
    }
}
