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


        public Task<bool> SaveProductAsync(string categoryid, List<ProductsDTO> productDtos)
        {
            return _productsRepository.SaveProductAsync(categoryid,productDtos);
        }

        public Task<ProductsDTO> GetProductsbyId(string id)
        {
            return _productsRepository.GetProductsbyId(id);
        }

        public Task<bool> UpdateProduct(string id, ProductsDTO productDto)
        {
            return _productsRepository.UpdateProduct(id, productDto);
        }

        public Task<bool> DeleteProductbyId(string id)
        {
           return _productsRepository.DeleteProductbyId(id);
        }
    }
}
