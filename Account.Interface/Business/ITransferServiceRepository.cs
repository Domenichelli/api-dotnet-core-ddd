using Account.Domain.Contracts;
using Account.Domain.Entities;
using Account.Domain.Response;
using System;
using System.Collections.Generic;

namespace Account.Interface.Business
{
    public interface ITransferServiceRepository
    {
        bool GetHasBalance(Guid AccountID, decimal value);
        ResultGeneric<PostTransfersResponse> Transfer(PostTransferAccountRequest request);
        ResultGeneric<PostTransfersResponse> DepositAccount(Guid AccountID, decimal value);
        ResultGeneric<GetExtractResponse> GetExtract(Guid AccountID);
    }
}
