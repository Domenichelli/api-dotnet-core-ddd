using Account.Domain.Entities;
using Account.Domain.Response;

namespace Account.Interface.Business
{
    public interface IClienteServiceRepository
    {
        ResultGeneric<ClientEntity> Register(ClientEntity entity);
    }
}
