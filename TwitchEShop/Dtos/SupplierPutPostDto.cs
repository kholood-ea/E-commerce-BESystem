using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchEShop.Dtos
{
    public class SupplierPutPostDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }


        public string Description { get; set; }
        public string Website { get; set; }
    }
}
