using Account.Domain.Contracts;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Converters
{
    public class TransferConverter
    {
        public static TransferEntity Parse(PostTransferAccountRequest entity)
        {
            if (entity == null) return new TransferEntity();
            return new TransferEntity()
            {
                AccountIDfrom = entity.AccountIDfrom,
                AccountIDto = entity.AccountIDto,
                value = entity.value
            };
        }

        public static TransferEntity Parse(Guid accountID, decimal value)
        {
            return new TransferEntity()
            {
                AccountIDto = accountID,
                value = value
            };
        }

        public static PostTransfersResponse Parse(TransferEntity entity)
        {
            if (entity == null) return new PostTransfersResponse();
            return new PostTransfersResponse()
            {
                AccountIDFrom = entity.AccountIDfrom,
                AccountIDTo = entity.AccountIDto,
                Value = entity.value,
                DateTransfer = entity.CreatedDate
            };
        }

        public static TransferHistory ParseHistory(TransferEntity entity)
        {
            if (entity == null) return new TransferHistory();
            return new TransferHistory()
            {
                AccountIDFrom = entity.AccountIDfrom,
                AccountIDTo = entity.AccountIDto,
                Value = (entity.TypeTransaction == Enums.ETypeTransaction.Debit ? entity.value * -1 : entity.value),
                DateTransfer = entity.CreatedDate,
                TypeTransaction = entity.TypeTransaction.ToString(),
                TypePay = entity.TypePay.ToString()
            };
        }
    }
}
