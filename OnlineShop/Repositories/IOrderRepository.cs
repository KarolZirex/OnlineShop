using OnlineShop.Models;
using OnlineShop.ViewModels;
using System.Collections.Generic;

namespace OnlineShop.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        Order ReturnOrderToDelete(int id);
        void ReduceQuantity(int id);
        void AddOrder(Order obj);
        CreateNewOrderViewModel ReturnCreateNewOrder();
        List<Order> ReturnAllOrders();
    }
}