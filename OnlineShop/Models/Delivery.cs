using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{

        public class Delivery
        {
            public int Id { get; set; }
            [Required]
            [StringLength(40, MinimumLength = 3, ErrorMessage = "Delivery Type is required")] 
            public string Name { get; set; }
            [Required]
            public float Price { get; set; }

        }
    }

