using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(40,MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Price must be a Number and biggger then 0")]
        public float Price { get; set; }
        
        [Required(ErrorMessage = "Quantity must be a Number and biggger then 0")]
        
        public int Quantity { get; set; }

    }
}
