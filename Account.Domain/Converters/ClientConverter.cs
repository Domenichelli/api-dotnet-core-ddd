using Account.Domain.Contracts;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Converters
{
    public static class ClientConverter
    {
        public static ClientEntity Parse(PostClientAccountRequest entity)
        {
            if (entity == null) return new ClientEntity();
            return new ClientEntity()
            {
                Name = entity.Name,
                CPF = entity.CPF
            };
        }

        public static PostClientAccountResponse Parse(ClientEntity client, AccountEntity account)
        {
            if (client == null || account == null) return new PostClientAccountResponse();

            return new PostClientAccountResponse()
            {
                Name = client.Name,
                CPF = client.CPF,
                AccountID = account.AccountID,
                AgencyNumber = account.AgencyNumber,
                AccountNumber = account.AccountNumber
            };
        }
    }
}
