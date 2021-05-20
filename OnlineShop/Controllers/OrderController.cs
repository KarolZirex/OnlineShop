using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repositories;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly OnlineShopDbContext _db;

        private UnitOfWork _UnitOfWork { get; }

        public OrderController(OnlineShopDbContext db)
        {
            _db = db;
            _UnitOfWork = new UnitOfWork(_db);
        }

        public ActionResult Index()
        {
            return RedirectToAction("MyOrders");
        }
       
        public ActionResult MyOrders()
        {
            return View(_UnitOfWork.Orders.ReturnAllOrders());
        }

        //GET
        public ActionResult CreateNewOrder()
        {
            return View(_UnitOfWork.Orders.ReturnCreateNewOrder());
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewOrder(Order obj)
        {
            try
            {
                if (obj.Product.Id == 0 || obj.Delivery.Id == 0)
                    return View(_UnitOfWork.Orders.ReturnCreateNewOrder());

                _UnitOfWork.Orders.AddOrder(obj);
                _UnitOfWork.Complete();
                return RedirectToAction("MyOrders");
            }
            catch
            {
                return View(_UnitOfWork.Orders.ReturnCreateNewOrder());
            }        
        }

        // GET:
        public ActionResult DeleteOrder(int id)
        {    
            return View(_UnitOfWork.Orders.ReturnOrderToDelete(id));
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrder(Order order)
        {
            _UnitOfWork.Orders.Remove(order);
            _UnitOfWork.Complete();
            return RedirectToAction("MyOrders");
        }

    }
}
