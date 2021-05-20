using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        public IOrderRepository Orders { get; set; }
        public IProductRepository Products { get; set; }
        public ISalesRepository Sales { get; set; }
        public int Complete();
    }
}
