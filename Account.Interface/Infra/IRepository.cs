using System.Collections.Generic;

namespace Account.Interface.Infra
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
        bool Exists(int id);

        //List<T> FindWithPagedSearch(string query);
        //int GetCount(string query);
    }
}
