using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Repositories
{
    public interface IProductsRepository
    {
        Task<bool> SaveProductAsync(ProductsDTO productDto);

        Task<List<ProductsDTO>> GetAllProductsAsync();
    }
}
