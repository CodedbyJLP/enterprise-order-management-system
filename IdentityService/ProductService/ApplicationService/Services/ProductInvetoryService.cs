using ProductService.ApplicationService.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Repositories;

namespace ProductService.ApplicationService.Services
{
    public class ProductInvetoryService : IProductInvetoryService
    {
        private readonly IProductsInvetoryRepository _productInventoryRepository;

        public ProductInvetoryService(IProductsInvetoryRepository productInventoryRepository)
        {
            _productInventoryRepository = productInventoryRepository;
        }


        public Task<bool> SaveInventory(ProductInventoryDTO productinventory)
        {
            return _productInventoryRepository.SaveInventory(productinventory);
        }

        public Task<bool> UpdateInventorybyProductId(ProductInventoryDTO productinventory)
        {
            return _productInventoryRepository.UpdateInventorybyProductId(productinventory);
        }

        public Task<ProductInventoryDTO> GetInventoryByProductId(string id)
        {
            return _productInventoryRepository.GetInventoryByProductId(id);
        }

    }
}
