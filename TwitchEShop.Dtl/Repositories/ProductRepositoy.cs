using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitchEShop.Domain.Interfaces;
using TwitchEShop.Domain.Models;

namespace TwitchEShop.Dal.Repositories
{
    public class ProductRepositoy : BaseRepository<Product>, IProductRepository
    {
        public ProductRepositoy(EShopDBContext context):base (context)
        {

        }
    //    private readonly EShopDBContext _context;
    //    public ProductRepositoy(EShopDBContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<Product> CreateAsync(Product product)
    //    {
    //        _context.Products.Add(product);
    //        await _context.SaveChangesAsync();
    //        return product;
    //    }

    //    public async Task<bool> DeleteAsync(int productId)
    //    {
    //        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
    //        _context.Products.Remove(product);
    //        await _context.SaveChangesAsync();
    //        return true;
    //                }

    //    public async Task<IEnumerable<Product>> GetAllAsync()
    //    {
    //        return await _context.Products.ToListAsync();   
    //    }

    //    public async Task<Product> GetByIdAsync(int productId)
    //    {
    //        return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);        }

    //    public async Task<bool> UpdateAsync(Product updatedProduct)
    //    {
    //        var product =await _context.Products.FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);
    //        product.Name = updatedProduct.Name;
    //        product.PhotoUrl = updatedProduct.PhotoUrl;
    //        product.Price = updatedProduct.Price;
    //        product.Supplier = updatedProduct.Supplier;
    //        _context.Products.Update(product);
    //        await _context.SaveChangesAsync();
    //        return true;
    //    }
    }
}
