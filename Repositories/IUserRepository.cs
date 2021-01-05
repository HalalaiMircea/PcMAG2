using PcMAG2.Models;
using PcMAG2.Models.Entities;

namespace PcMAG2.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetByEmailAndPassword(string email, string password);

        User? FindByEmail(string email);
    }
}