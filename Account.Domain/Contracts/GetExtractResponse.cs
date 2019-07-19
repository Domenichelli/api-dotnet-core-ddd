using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Contracts
{
    public class GetExtractResponse
    {
        public List<TransferHistory> Transfer { get; set; }
        public decimal balance { get; set; }
    }

    public class TransferHistory
    {
        public Guid AccountIDFrom { get; set; }
        public Guid AccountIDTo { get; set; }
        public decimal Value { get; set; }
        public DateTime DateTransfer { get; set; }
        public string TypeTransaction { get; set; }
        public string TypePay { get; set; }
    }
}
