using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchEShop.Domain.Interfaces;
using TwitchEShop.Domain.Models;
using TwitchEShop.Dtos;

namespace TwitchEShop.Controllers
{
    [Route("/api/[controller]")]

    public class SuppliersController : Controller
    {
        private readonly ISupplierRepository _suppliers;
        public SuppliersController(ISupplierRepository suppliers)
        {

            _suppliers = suppliers;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            List<SupplierGetDto> suppliersDtos = new List<SupplierGetDto>();
            var suppliers = await _suppliers.GetAllAsync();
            foreach (var supplier in suppliers)
            {
                var supplierDto = new SupplierGetDto()
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                    Description = supplier.Description,
                    Website = supplier.Website
                };
                suppliersDtos.Add(supplierDto);
            }

            return Ok(suppliersDtos);
        }

        [Route("{id}")]
        [HttpGet]

        public async Task<IActionResult> GetSupplierById(int id)
        {
            var supplier = await _suppliers.GetByIdAsync(id);


            if (supplier == null)
            {
                return NotFound();
            }
            var supplierDto = new SupplierGetDto()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Description = supplier.Description,
                Website = supplier.Website
            };   
            return Ok(supplierDto);


        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] SupplierPutPostDto supplierDTO)
        {
            if (ModelState.IsValid)
            {

                var supplier = new Supplier();
                supplier.Name = supplierDTO.Name;
                supplier.Description = supplierDTO.Description;
                supplier.Website = supplierDTO.Website;
                var response = await _suppliers.CreateAsync(supplier);
                var supplierGet = new SupplierGetDto();
                supplierGet.Id = response.Id;
                supplierGet.Name = response.Name;
                supplierGet.Website = response.Website;
                supplierGet.Description = response.Description;
                return Created("Created", supplierGet);
            }

            return BadRequest("Supplier info not acceptable");
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(int id,[FromBody] SupplierPutPostDto updatedSupplier)
        {
            if (ModelState.IsValid)
            {
                var supplier = new Supplier();
                supplier.Id = id;
                supplier.Name = updatedSupplier.Name;
                supplier.Description = updatedSupplier.Description;
                supplier.Website = updatedSupplier.Website;
                var respone = await _suppliers.UpdateAsync(supplier);
                if (respone)
                    return Ok("Supplier has been updated");
                else return BadRequest("Something went wrong");               
            }
            return BadRequest ("Supplier info not Valid");
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _suppliers.DeleteAsync(id);

            if (result)
            {
            return Ok("Supplier deleted Successfully");
            }
            else
            {
                return BadRequest("Something Went Wrong while deleting");
            }

        }

    }
    }
