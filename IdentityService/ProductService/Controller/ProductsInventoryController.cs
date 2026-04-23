using Microsoft.AspNetCore.Mvc;
using ProductService.ApplicationService.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Controller
{
    [Route("api/inventory")]
    public class ProductsInventoryController : ControllerBase
    {
        private readonly IProductInvetoryService _productsInventoryService;

        public ProductsInventoryController(IProductInvetoryService productsInventoryService)
        {
            _productsInventoryService = productsInventoryService;
        }

        [HttpPost("inventory")]
        public async Task<IActionResult> SaveInventory(ProductInventoryDTO productinventory)
        {
            var result = await _productsInventoryService.SaveInventory(productinventory);
            if (result == null)
            {
                return BadRequest("Failed to save inventory.");
            }
            return Ok(result);
        }
        [HttpPut("inventory")]
        public async Task<IActionResult> UpdateInventory(ProductInventoryDTO productinventory)
        {
            var result = await _productsInventoryService.UpdateInventorybyProductId(productinventory);
            if (!result)
            {
                return BadRequest("Failed to update inventory.");
            }
            return Ok(result);
        }

        [HttpGet("inventory/{id}")]
        public async Task<IActionResult> GetInventoryByProductId(string id)
        {
            var result = await _productsInventoryService.GetInventoryByProductId(id);
            if (result == null)
            {
                return NotFound("Inventory not found for the given product ID.");
            }
            return Ok(result);

        }



    }



}
