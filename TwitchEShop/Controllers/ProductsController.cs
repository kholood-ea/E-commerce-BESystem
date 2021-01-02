using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchEShop.Domain.Interfaces;
using TwitchEShop.Domain.Models;
using TwitchEShop.Dtos;
using TwitchEShop.Interfaces;

namespace TwitchEShop.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController:Controller
    {
        //private readonly ISeeder _seeder;
        private readonly IProductRepository _products;
        public ProductsController(IProductRepository products)
        {

            _products = products;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts() {
            // return specific fields of model
         List<ProductGetDto> productDTO = new List<ProductGetDto>();

            var products =await _products.GetAllAsync();
            //var products = _seeder.GetAllProducts();
            foreach (var product in products)
            {
                var dto = new ProductGetDto();
                dto.Id = product.Id;
                dto.Name = product.Name;
                dto.Description = product.Description;
                dto.Price = product.Price;
                dto.SupplierId = product.SupplierId;
                dto.PhotoUrl = product.PhotoUrl;
                productDTO.Add(dto);
            }
            //var product = new Product();
            //product.Id = 1;
            //product.Name = "Shampoo";
            //product.Price = 12.82f;

            //return Ok(_seeder.GetAllProducts());
            return Ok(productDTO);

        }
        [Route("{id}")]
        [HttpGet]

        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _products.GetByIdAsync(id);

            //var product = _seeder.GetAllProducts().FirstOrDefault(p => p.Id == id);

            if (product==null)
            {
                return NotFound();
            }
            var productDTO = new ProductGetDto();
            productDTO.Id = product.Id;
            productDTO.Name = product.Name;
            productDTO.Description = product.Description;
            productDTO.Price = product.Price;
            productDTO.SupplierId = product.SupplierId;
            productDTO.PhotoUrl = product.PhotoUrl;
            //var product = new Product();
            //product.Id = id;
            //product.Name = $"product No.{id}";
            //product.Price = 12.82f;
            //return Ok(product);
            return Ok(productDTO);



        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]ProductPutPostDto productDTO)
        {
            if (ModelState.IsValid)
            {

            var product = new Product();
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
                //product.PhotoUrl = "";
              product.SupplierId = productDTO.SupplierId;
                var addResult = await _products.CreateAsync(product);
                if (addResult==null)
                {
                    return BadRequest("try again");
                }
            //var addResult=_seeder.addProduct(product);
            // if (!addResult)
            // {
            //     return BadRequest("try again");
            //         }
            // return Ok(product);
            return Created("created", productDTO);
            }
            return BadRequest();
        }
        [Route("{id}")]
        [HttpPut]

        public async Task <IActionResult> UpdateProduct( int id,[FromBody] ProductPutPostDto updatedProductDTO)
        {
            var updatedProduct = new Product();
            updatedProduct.Id = id;
            updatedProduct.Name = updatedProductDTO.Name;
            updatedProduct.Description = updatedProduct.Description;
            updatedProduct.Price = updatedProductDTO.Price;
            updatedProduct.PhotoUrl = updatedProductDTO.PhotoUrl;
            updatedProduct.SupplierId = updatedProductDTO.SupplierId;
            var updateReslt = await _products.UpdateAsync(updatedProduct);

            //var updateReslt = _seeder.updateProduct(updatedProduct);
            if (updateReslt)
            {
                return Ok(updatedProduct);
            }
            return BadRequest("product wasnt found try again");
        }

        [Route("{id}")]
        [HttpDelete]
        public  async Task<IActionResult> deleteProduct(int id)
        {
            var deleteResult = await _products.DeleteAsync(id);

            //var deleteResult = _seeder.deleteProduct(id);
            if (!deleteResult)
            {
                return BadRequest(" product Not Found");
            }

            return Ok("Deleted");
        }
    }
}
