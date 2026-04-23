using ProductService.Domain.Entities;

namespace ProductService.ApplicationService.Interfaces
{
    public interface ICategoriesService
    {

        Task<bool> SaveCategoryAsync(CategoryDto categoryDto);

        Task<CategoryDto> GetCategoryByIdAsync(string id);
        Task<bool> UpdateCategorybyId(CategoryDto categoryDto);
        Task<bool> DeleteCategoryByIdAsync(string id);
    }
}
