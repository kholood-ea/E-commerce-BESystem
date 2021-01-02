﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchEShop.Domain.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
