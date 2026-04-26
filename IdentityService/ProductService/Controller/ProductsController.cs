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

        [HttpPost("products/{categoryid}")]
        public async Task<IActionResult> SaveProduct(string categoryid, List<ProductsDTO> productDtos)
        {
            if (ModelState.IsValid)
            {
                var result = await _productsService.SaveProductAsync(categoryid, productDtos);
                if (!result)
                {
                    return BadRequest("Failed to save product.");
                }

                return Ok("Product saved successfully.");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> Products(string id)
        {
            var products = await _productsService.GetProductsbyId(id);
            return Ok(products);

        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> Products(ProductsDTO productDto, string id)
        {
            var products = await _productsService.UpdateProduct(id, productDto);
            if (!products)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProducts(string id)
        {
            var products = await _productsService.DeleteProductbyId(id);
            if (!products)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> SearchProducts(string keyword)
        {
            var products = await _productsService.SearchProducts(keyword);
            return Ok(products);

        }
        [HttpGet("products/filter/{categoryId}/{minprice}/{maxprice}")]
        public async Task<IActionResult> SearchProductsbyCategoryId(string categoryId, decimal minprice, decimal maxprice)
        {
            var products = await _productsService.SearchProductsbyCategoryId(categoryId, minprice, maxprice);
            return Ok(products);

        }
        [HttpGet("products/sort/{field}/{order}")]
        public async Task<IActionResult> SortProductsbyField(string field, string order)
        {
            var products = await _productsService.SortProductsbyField(field, order);
            return Ok(products);

        }
    }
}
