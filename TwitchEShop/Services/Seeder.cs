using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchEShop.Domain.Models;
using TwitchEShop.Interfaces;

namespace TwitchEShop.Services
{
    public class Seeder : ISeeder
    {
        private List<Product> _products = new List<Product>();

        public bool addProduct(Product product)
        {
            _products.Add(product);
            return true;
        }

        public bool deleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product!=null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }

        public List<Product> GetAllProducts()
        {
            var product1 = new Product
            {
                Id = 2,
                Name = "tea",
                Description = "warm thing to drink",
                Price = 12.45
            };
            _products.Add(product1);
            var product2 = new Product
            {
                Id = 3,
                Name = "coffe",
                Description = "warm and refreshing thing to drink",
                Price = 20.45
            };
            _products.Add(product2);
            return _products;
        }

        public bool updateProduct( Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (product!=null)
            {
            _products.Remove(product);
            _products.Add(updatedProduct);
                return true;
            }
            return false;
        }
    }
}
