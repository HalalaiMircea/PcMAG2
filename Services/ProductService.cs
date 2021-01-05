using System.Collections.Generic;
using PcMAG2.Models;
using PcMAG2.Models.Entities;
using PcMAG2.Repositories;

namespace PcMAG2.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product? GetProductById(int productId)
        {
            return _productRepository.FindById(productId);
        }
    }
}