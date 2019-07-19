using System.Collections.Generic;
using System.Linq;
using Account.Interface.Infra;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.MySql.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly MySqlContext _context;

        public BaseRepository(MySqlContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _context.Set<T>().Any(_ => _.Equals(id));
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
