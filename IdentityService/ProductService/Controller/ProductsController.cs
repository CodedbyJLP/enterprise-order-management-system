using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.ApplicationService.Interfaces;
using ProductService.Domain.Entities;

namespace IdentityService.Controller
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;


        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost("saveproduct")]
        public async Task<IActionResult> SaveProduct(ProductsDTO productDto)
        {
            var result = await _productsService.SaveProductAsync(productDto);
            if (result)
            {
                return Ok("Product saved successfully.");
            }
            return BadRequest("Failed to save product.");

        }

        [HttpGet("getallproducts")]
        public async Task<IActionResult> GetAllProducts()
        {

            var products = await _productsService.GetAllProductsAsync();
            return Ok(products);


        }
    }
}
