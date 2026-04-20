using MongoDB.Bson;
using MongoDB.Driver;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _dbContext;

        public ProductsRepository(ProductsContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> SaveProductAsync(ProductsDTO productDto)
        {
            try
            {
                ProductsEntity productsEntity = new ProductsEntity()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = productDto.Name,
                    Price = productDto.Price,

                };
                await _dbContext.Products.InsertOneAsync(productsEntity);

                return true;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<List<ProductsDTO>> GetAllProductsAsync()
        {
            try
            {
                List<ProductsDTO> productsDtoList = new List<ProductsDTO>();
                List<ProductsEntity> products = await _dbContext.Products.Find(_ => true).ToListAsync();
                if (products.Any())
                {
                    productsDtoList = products.Select(p => new ProductsDTO
                    {
                        Id = p.Id.ToString(),
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        CategoryId = p.CategoryId,
                        IsActive = p.IsActive,
                        CreatedAt = p.CreatedAt,
                        UpdatedAt = p.UpdatedAt
                    }).ToList();
                }
                return productsDtoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
