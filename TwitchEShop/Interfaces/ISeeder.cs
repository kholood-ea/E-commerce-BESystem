using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchEShop.Domain.Models;

namespace TwitchEShop.Interfaces
{
    public interface ISeeder
    {
        List<Product> GetAllProducts();
        bool addProduct(Product product);
        bool updateProduct(Product updatedProduct);
        bool deleteProduct(int id);
    }
}
