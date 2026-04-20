using ProductService.ApplicationService.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Repositories;

namespace ProductService.ApplicationService.Services
{
    public class ProductsService : IProductsService
    {
        public IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }


        public Task<bool> SaveProductAsync(ProductsDTO productDto)
        {
            return _productsRepository.SaveProductAsync(productDto);
        }

        public Task<List<ProductsDTO>> GetAllProductsAsync()
        {
            return _productsRepository.GetAllProductsAsync();
        }
    }
}
