using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Repositories
{
    public interface IProductsRepository
    {
        Task<bool> SaveProductAsync(string categoryid, List<ProductsDTO> productDtos);

        Task<ProductsDTO> GetProductsbyId(string id);
        Task<bool> UpdateProduct(string id, ProductsDTO productDto);
        Task<bool> DeleteProductbyId(string id);
        Task<List<ProductsDTO>> SearchProducts(string keyword);
        Task<List<ProductsDTO>> SearchProductsbyCategoryId(string categoryId, decimal minprice, decimal maxprice);
        Task<List<ProductsDTO>> SortProductsbyField(string field, string order);
    }
}
