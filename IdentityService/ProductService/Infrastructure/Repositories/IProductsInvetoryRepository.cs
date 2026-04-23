using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Repositories
{
    public interface IProductsInvetoryRepository
    {
       
        Task<bool> SaveInventory(ProductInventoryDTO productinventory);
        Task<bool> UpdateInventorybyProductId(ProductInventoryDTO productinventory);
        Task<ProductInventoryDTO> GetInventoryByProductId(string id);
    }
}
