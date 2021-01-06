using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PcMAG2.Models;

namespace PcMAG2.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PcmagDbContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(PcmagDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Create(T entity)
        {
            _table.Add(entity);
        }

        public void CreateRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
        }

        public void HardDelete(T entity)
        {
            _table.Remove(entity);
        }

        public T? FindById(long id)
        {
            return _table.Find(id);
        }

        public List<T> FindAll()
        {
            return _table.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}