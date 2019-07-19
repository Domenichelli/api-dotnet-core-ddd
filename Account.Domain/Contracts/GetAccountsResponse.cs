using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Contracts
{
    public class GetAccountsResponse
    {
        public string CPF { get; set; }

        public Guid AccountID { get; set; }

        public Guid ClientID { get; set; }

        public string Agency { get; set; }

        public string Account { get; set; }

        public decimal Value { get; set; }
    }
}
