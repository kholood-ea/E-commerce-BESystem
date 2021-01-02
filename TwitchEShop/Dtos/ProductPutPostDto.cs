using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchEShop.Dtos
{
    public class ProductPutPostDto
    {
        [Required]
        [MaxLength(25)]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]

        public string Description { get; set; }
        [Required]
        [Range(0,10000000)]
        public double Price { get; set; }
        public int SupplierId { get; set; }
 
        public string PhotoUrl { get; set; }
    }
}
