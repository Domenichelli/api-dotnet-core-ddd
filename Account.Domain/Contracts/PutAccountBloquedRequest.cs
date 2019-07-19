using System;

namespace Account.Domain.Contracts
{
    public class PutBloquedAccountRequest
    {
        public Guid AccountID { get; set; }

        public bool Block { get; set; }
    }
}
