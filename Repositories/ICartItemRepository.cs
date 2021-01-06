using System.Collections.Generic;
using PcMAG2.Models.Entities;

namespace PcMAG2.Repositories
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        List<CartItem> FindAllByUserId(long userId);
        CartItem? FindById(long userId, long productId);
    }
}