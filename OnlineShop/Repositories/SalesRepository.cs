using OnlineShop.Data;

namespace OnlineShop.Repositories
{
    internal class SalesRepository : ISalesRepository
    {
        private OnlineShopDbContext _db;

        public SalesRepository(OnlineShopDbContext db)
        {
            _db = db;
        }
    }
}