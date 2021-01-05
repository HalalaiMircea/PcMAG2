using System.Collections.Generic;

#nullable disable

namespace PcMAG2.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public string ImageUrl { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
