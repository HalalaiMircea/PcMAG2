using System.Linq;
using PcMAG2.Models;
using PcMAG2.Models.Entities;

namespace PcMAG2.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PcmagDbContext context) : base(context)
        {
        }

        public User? FindByEmailAndPassword(string email, string password)
        {
            return _table.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User? FindByEmail(string email)
        {
            return _table.FirstOrDefault(u => u.Email == email);
        }
    }
}