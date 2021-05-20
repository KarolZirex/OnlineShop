using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name must be between 3-40 character.")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Lastname must be between 3-40 character.")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "City must be between 3-40 character.")]
        public string City{ get; set; }
        
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Street Adress must be between 3-40 character.")]
        public string StreetAdress { get; set; }
        
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Zip Code is wrong.")]
        public string ZipCode{ get; set; }

    }
}
