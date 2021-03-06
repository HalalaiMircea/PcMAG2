﻿using System.Collections.Generic;
using System.Linq;
using PcMAG2.Models;
using PcMAG2.Models.Entities;

namespace PcMAG2.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(PcmagDbContext context) : base(context)
        {
        }
    }
}