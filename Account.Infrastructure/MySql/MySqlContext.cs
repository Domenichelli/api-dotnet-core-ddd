using Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Infrastructure.MySql
{
    public class MySqlContext : DbContext
    {
        public DbSet<AccountEntity> AccountEntities { get; set; }
        public DbSet<ClientEntity> ClientEntities { get; set; }
        public DbSet<TransferEntity> TransferEntities { get; set; }

        public MySqlContext(DbContextOptions options) : base (options)
        {

            
        }
    }
}
