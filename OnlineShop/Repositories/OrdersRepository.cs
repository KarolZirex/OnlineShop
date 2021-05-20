using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Repositories
{
    internal class OrdersRepository :Repository<Order>, IOrderRepository
    {
        public OrdersRepository(OnlineShopDbContext context)
        : base(context) { }

        public Order ReturnOrderToDelete(int id)
        {    
            return _db.Orders.Include(p => p.Product)
                .Include(d => d.Delivery)
                .Include(c => c.Customer)
                .FirstOrDefault(x => x.Id == id);
        }
        public List<Order> ReturnAllOrders()
        {
            var allOrders = _db.Orders
                .Include(p => p.Product)
                .Include(d => d.Delivery)
                .Include(c => c.Customer).ToList();
            return allOrders;
        }
        public void AddOrder(Order obj)
        {
            var newOrder = new Order
            {
                Customer = obj.Customer,
                ProductId = obj.Product.Id,
                DeliveryId = obj.Delivery.Id,
                Price = obj.Price
            };

            Add(newOrder);
            ReduceQuantity(obj.Product.Id);

        }
        public void ReduceQuantity(int id)
        {
            Product product = _db.Products.Find(id);
            product.Quantity = product.Quantity - 1;
            _db.Update(product);

        }
        public CreateNewOrderViewModel ReturnCreateNewOrder()
        {
            var products = _db.Products.Where(x => x.Quantity > 0).ToList();
            var deliveries = _db.Deliveries.ToList();
            var customer = _db.Customers.ToList();
            var newOrder = new CreateNewOrderViewModel
            {
                ListOfCustomers = customer,
                ListOfProducts = products,
                DeliveryTypes = deliveries
            };
            return newOrder;
        }
    }
}