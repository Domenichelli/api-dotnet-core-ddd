using Account.Domain.Entities;
using Account.Domain.Response;
using Account.Interface.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Application.Business
{
    public class ClientService : IClienteServiceRepository
    {
        public ResultGeneric<ClientEntity> Register(ClientEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
