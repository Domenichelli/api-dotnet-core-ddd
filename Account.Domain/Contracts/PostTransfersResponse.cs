using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Contracts
{
    public class PostTransfersResponse
    {
        public Guid AccountIDFrom { get; set; }

        public Guid AccountIDTo { get; set; }

        public decimal Value { get; set; }

        public DateTime DateTransfer { get; set; }
    }
}
