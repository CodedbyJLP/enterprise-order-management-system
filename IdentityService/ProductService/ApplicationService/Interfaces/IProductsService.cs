using ProductService.Domain.Entities;

namespace ProductService.ApplicationService.Interfaces
{
    public interface IProductsService
    {

        Task<bool> SaveProductAsync(string categoryid, List<ProductsDTO> productDtos);

        Task<ProductsDTO> GetProductsbyId(string id);
        Task<bool> UpdateProduct(string id, ProductsDTO productDto);
        Task<bool> DeleteProductbyId(string id);
    }
}
