using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchEShop.Domain.Models;

namespace TwitchEShop.Dtos
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SupplierId { get; set; }
        public string PhotoUrl { get; set; }
    }
}
