using Account.Domain.Entities;
using Account.Interface.Infra;
using System.Linq;

namespace Account.Infrastructure.MySql.Repositories
{
    public class ClientRepository : BaseRepository<ClientEntity>, IClientRepository
    {
        public ClientRepository(MySqlContext context) : base(context) { }

        public ClientEntity getByDocument(string document)
        {
            return GetAll().Where(_ => _.CPF.Equals(document)).FirstOrDefault();
        }
    }
}
