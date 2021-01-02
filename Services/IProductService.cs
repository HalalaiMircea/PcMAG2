using System.Collections.Generic;
using PcMAG2.Models;

namespace PcMAG2.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        
    }
}