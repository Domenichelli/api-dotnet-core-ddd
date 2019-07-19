using Account.Domain.Contracts;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Converters
{
    public static class AccountConverter
    {
        public static AccountEntity Parse(PostClientAccountRequest entity)
        {
            if (entity == null) return new AccountEntity();
            return new AccountEntity()
            {
                AccountNumber = entity.AccountNumber,
                AgencyNumber = entity.AgencyNumber
            };
        }

        public static GetAccountsResponse Parse(AccountEntity entity, string CPF = "")
        {
            if (entity == null) return new GetAccountsResponse();
            return new GetAccountsResponse()
            {
                Agency = entity.AgencyNumber,
                Account = entity.AccountNumber,
                AccountID = entity.AccountID,
                ClientID = entity.ClientID,
                CPF = CPF,
                Value = entity.Balance
            };
        }
    }
}
