using ProductService.Domain.Entities;

namespace ProductService.ApplicationService.Interfaces
{
    public interface IProductInvetoryService
    {
        
        Task<bool> SaveInventory(ProductInventoryDTO productinventory);
        Task<bool> UpdateInventorybyProductId(ProductInventoryDTO productinventory);
        Task<ProductInventoryDTO> GetInventoryByProductId(string id);
    }
}
