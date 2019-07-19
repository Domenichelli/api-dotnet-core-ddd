using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Contracts
{
    public class PostDepositAccountRequest
    {
        /// <summary>
        /// valor da transferencia
        /// </summary>
        public decimal value { get; set; }
    }
}
