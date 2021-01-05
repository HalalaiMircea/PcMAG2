#nullable disable

namespace PcMAG2.Models.Entities
{
    public partial class CartItem
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
