using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitchEShop.Domain.Models;

namespace TwitchEShop.Domain.Interfaces
{
   public interface IProductRepository:IRepository<Product>
    {
        //Task<IEnumerable<Product>> GetAllProductsAsync();
        //Task<Product> GetProductByIdAsync(int productId);
        //Task<Product> CreateProductAsync(Product product);
        //Task<bool> UpdateProductAsync(Product updatedProduct);
        //Task<bool> DeleteProductAsync(int productId);
    }
}
