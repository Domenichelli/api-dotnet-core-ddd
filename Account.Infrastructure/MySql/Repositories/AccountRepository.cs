using System;
using System.Collections.Generic;
using System.Linq;
using Account.Domain.Entities;
using Account.Interface.Infra;

namespace Account.Infrastructure.MySql.Repositories
{
    public class AccountRepository : BaseRepository<AccountEntity> , IAccountRepository
    {
        public AccountRepository(MySqlContext context) : base(context) { }

        public bool AccountExists(string agency, string account)
        {
            return GetAll().Exists(_ => _.AgencyNumber.Equals(agency) && _.AccountNumber.Equals(account));
        }

        public AccountEntity GetAccountByAccountID(Guid accountID)
        {
            return GetAll().Where(_ => _.AccountID.Equals(accountID)).FirstOrDefault();
        }

        public List<AccountEntity> GetAllAccountsByClientID(Guid clientID)
        {
            return GetAll().Where(_ => _.ClientID.Equals(clientID)).ToList();
        }
    }
}
