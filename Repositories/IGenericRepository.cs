using System.Collections.Generic;

namespace PcMAG2.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T entity);

        void CreateRange(IEnumerable<T> entities);

        void HardDelete(T entity);

        T? FindById(long id);

        List<T> FindAll();

        bool SaveChanges();

        void Update(T entity);
    }
}