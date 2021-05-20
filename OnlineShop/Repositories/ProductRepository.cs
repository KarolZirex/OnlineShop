using OnlineShop.Data;
using OnlineShop.Models;
using System.Collections.Generic;

namespace OnlineShop.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopDbContext context)
        : base(context) {  }

      
    }
}