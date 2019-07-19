using Account.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Account.Interface.Infra
{
    public interface ITransferRepository
    {
        void Insert(TransferEntity entity);
        void Delete(TransferEntity entity);
        List<TransferEntity> GetAllTransfersAccount(Guid AccoundID);
    }
}
