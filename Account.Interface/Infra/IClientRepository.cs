using Account.Domain.Entities;

namespace Account.Interface.Infra
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        ClientEntity getByDocument(string document);
    }
}
