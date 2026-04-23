using MongoDB.Bson;
using MongoDB.Driver;
using ProductService.Domain.Entities;
using System;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductsInvetoryRepository : IProductsInvetoryRepository
    {
        private readonly ProductsContext _dbContext;

        public ProductsInvetoryRepository(ProductsContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<bool> SaveInventory(ProductInventoryDTO productinventory)
        {
            try
            {
                ProductInventory inventory = new ProductInventory
                {
                    Id = ObjectId.GenerateNewId(),
                    ProductId = ObjectId.Parse(productinventory.ProductId),
                    Available = productinventory.Available,
                    Reserved = productinventory.Reserved,
                    LastUpdated = DateTime.UtcNow
                };
                await _dbContext.ProductInventory.InsertOneAsync(inventory);
                var product = Builders<ProductsEntity>.Filter.Eq(p => p.Id, ObjectId.Parse(productinventory.ProductId));
                var updateproduct = Builders<ProductsEntity>.Update.
                     Set(p => p.Quantity, productinventory.Available).
                     Set(p => p.UpdatedAt, DateTime.UtcNow);
                await _dbContext.Products.UpdateOneAsync(product, updateproduct);

                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> UpdateInventorybyProductId( ProductInventoryDTO productinventory)
        {
            try
            {
                var inventory = Builders<ProductInventory>.Filter.Eq(p => p.Id, ObjectId.Parse(productinventory.Id));
                if (inventory != null)
                {
                    int available = productinventory.Available - productinventory.Reserved;
                    if (available > 0)
                    {
                        var updateinventory = Builders<ProductInventory>.Update.
                            Set(p => p.Available, available).
                            Set(p => p.Reserved, productinventory.Reserved).
                            Set(p => p.LastUpdated, DateTime.UtcNow);
                        await _dbContext.ProductInventory.UpdateOneAsync(inventory, updateinventory);
                    }
                }
                return true;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ProductInventoryDTO> GetInventoryByProductId(string id)
        {
            try
            {
                ProductInventoryDTO productInventoryDTO = new ProductInventoryDTO();
                var inventory = await _dbContext.ProductInventory.Find(p => p.ProductId == ObjectId.Parse(id)).FirstOrDefaultAsync();
                if (inventory != null)
                {
                    productInventoryDTO.Id = inventory.Id.ToString();
                    productInventoryDTO.ProductId = inventory.ProductId.ToString();
                    productInventoryDTO.Available = inventory.Available;
                    productInventoryDTO.Reserved = inventory.Reserved;
                    productInventoryDTO.LastUpdated = inventory.LastUpdated;
                }
                return productInventoryDTO;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
