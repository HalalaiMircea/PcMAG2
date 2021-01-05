using PcMAG2.Models;
using PcMAG2.Models.Entities;

namespace PcMAG2.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User? GetByEmailAndPassword(string email, string password);
    }
}