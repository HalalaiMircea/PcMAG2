using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PcMAG2.Models;
using PcMAG2.Models.Entities;

namespace PcMAG2.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(PcmagDbContext context) : base(context)
        {
        }

        public List<CartItem> FindAllByUserId(long userId)
        {
            return _table.AsNoTracking()
                .Where(i => i.UserId == userId)
                .Include(i => i.Product)
                .ToList();
        }

        public CartItem? FindById(long userId, long productId)
        {
            return _table.Find(userId, productId);
        }
    }
}