using System;
using System.Collections.Generic;
using System.Linq;
using Account.Domain.Entities;
using Account.Interface.Infra;

namespace Account.Infrastructure.MySql.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        protected readonly MySqlContext _context;

        public TransferRepository(MySqlContext context)
        {
            _context = context;
        }

        public void Delete(TransferEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<TransferEntity> GetAllTransfersAccount(Guid AccoundID)
        {
            return _context.Set<TransferEntity>().Where(_ => _.AccountIDfrom.Equals(AccoundID) || _.AccountIDto.Equals(AccoundID)).ToList();
        }

        public void Insert(TransferEntity entity)
        {
            _context.Set<TransferEntity>().Add(entity);
            _context.SaveChanges();
        }
    }
}
