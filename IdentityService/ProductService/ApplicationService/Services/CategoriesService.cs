using ProductService.ApplicationService.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Repositories;

namespace ProductService.ApplicationService.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

      

        public Task<bool> SaveCategoryAsync(CategoryDto categoryDto)
        {
            return _categoriesRepository.SaveCategoryAsync(categoryDto);
        }

        public Task<CategoryDto> GetCategoryByIdAsync(string id)
        {
           return _categoriesRepository.GetCategoryByIdAsync(id);
        }

        public Task<bool> UpdateCategorybyId(CategoryDto categoryDto)
        {
           return _categoriesRepository.UpdateCategorybyId(categoryDto);
        }

        public Task<bool> DeleteCategoryByIdAsync(string id)
        {
            return _categoriesRepository.DeleteCategoryByIdAsync(id);
        }
    }
}
