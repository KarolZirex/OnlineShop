using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private OnlineShopDbContext _db;
        private UnitOfWork _UnitOfWork;

        public ProductController(OnlineShopDbContext db)
        {
            _db =db;
            _UnitOfWork = new UnitOfWork(_db);
        }

        public ActionResult Index()
        {
            return RedirectToAction("MyProducts");
        }
        public ActionResult MyProducts()
        {
            return View(_UnitOfWork.Products.GetAll());
        }

        //GET
        public ActionResult CreateNewProduct()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewProduct(Product obj)
        {
            if (obj.Price < 0 || obj.Price.Equals(null) ||
                obj.Quantity < 0 || obj.Quantity.Equals(null) ||
                obj.Name == "" || obj.Name.Length < 3)
            {
                return View();
            }
            else
            {
                _UnitOfWork.Products.Add(obj);
                _UnitOfWork.Complete();
                return RedirectToAction("MyProducts");
            }
        }

        // GET:
        public ActionResult DeleteProduct(int id)
            {    
                return View(_UnitOfWork.Products.Get(id));
            }

            // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(Product product)
            {
                _UnitOfWork.Products.Remove(product);
                _UnitOfWork.Complete();
                return RedirectToAction("MyProducts");
            }


            // GET
         public ActionResult AddQuantity(int id)
          {
              return View(_UnitOfWork.Products.Get(id));
          }
         // POST
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult AddQuantity(Product product)
            {
                   _UnitOfWork.Products.Update(product);
                   _UnitOfWork.Complete();
                   return RedirectToAction("MyProducts");
            }

}
}
