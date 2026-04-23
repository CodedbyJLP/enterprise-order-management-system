using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Repositories
{
    public interface ICategoriesRepository
    {
       
        Task<bool> SaveCategoryAsync(CategoryDto categoryDto);

        Task<CategoryDto> GetCategoryByIdAsync(string id);
        Task<bool> UpdateCategorybyId(CategoryDto categoryDto);
        Task<bool> DeleteCategoryByIdAsync(string id);
    }
}
