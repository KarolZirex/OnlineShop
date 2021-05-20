using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private OnlineShopDbContext _db;

        public IOrderRepository Orders { get; set ; }
        public IProductRepository Products { get ; set; }
        public ISalesRepository Sales { get ; set; }

        public UnitOfWork(OnlineShopDbContext db)
        {
            _db = db;
            Products = new ProductRepository(_db);
            Orders = new OrdersRepository(_db);
            Sales = new SalesRepository(_db);

        }
        public int Complete()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
