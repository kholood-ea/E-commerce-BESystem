using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchEShop.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public Name  Name { get; set; }
        public int Ssn { get; set; }
        public ICollection<ContactDetail> ContactDetails { get; set; }
        public string Username { get; set; }

    }
}
