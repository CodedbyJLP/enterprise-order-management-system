using ProductService.Domain.Entities;

namespace ProductService.ApplicationService.Interfaces
{
    public interface IProductsService
    {

        Task<bool> SaveProductAsync(ProductsDTO productDto);

        Task<List<ProductsDTO>> GetAllProductsAsync();
    }
}
