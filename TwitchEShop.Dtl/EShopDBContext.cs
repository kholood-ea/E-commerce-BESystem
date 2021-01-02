using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchEShop.Domain.Models;

namespace TwitchEShop.Dal
{
   public class EShopDBContext:DbContext
    {
        public EShopDBContext(DbContextOptions<EShopDBContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) { }

    }
}
