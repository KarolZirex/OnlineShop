using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class CreateNewOrderViewModel
    {
        public IEnumerable<Product> ListOfProducts { get; set; }
        public IEnumerable<Delivery> DeliveryTypes { get; set; }
        public IEnumerable<Customer> ListOfCustomers { get; set; }

        public Product Product { get; set; }
        public Delivery Delivery { get; set; }
        public Customer Customer { get; set; }
        public float Price { get; set; }


    }
}
