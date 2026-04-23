using Microsoft.AspNetCore.Mvc;
using ProductService.ApplicationService.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Controller
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoriesService _categoryService;

        public CategoryController(ICategoriesService categoryService)
        {
            _categoryService = categoryService;


        }
        [HttpPost("category")]
        public async Task<IActionResult> SaveCategory(CategoryDto categoryDto)
        {
            var result = await _categoryService.SaveCategoryAsync(categoryDto);
            if (!result)
            {
                return BadRequest("Failed to save category.");
            }
            return Ok(result);

        }
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);

        }
        [HttpPut("category")]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            bool iscategoryupdated = await _categoryService.UpdateCategorybyId(categoryDto);
            if (iscategoryupdated)
            {
                return NotFound();
            }

            return Ok(true);


        }

        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            bool isCategoryDeleted = await _categoryService.DeleteCategoryByIdAsync(id);
            if (!isCategoryDeleted)
            {
                return NotFound();
            }

            return Ok(true);
        }


    }
}
