using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        
        [Required]
        public int? DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        
        [Required]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public float Price { get; set; }

        public DateTime DateTime { get; set; } =  DateTime.Now;

     

    }
}
