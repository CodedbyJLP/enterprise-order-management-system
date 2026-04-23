using MongoDB.Bson;
using MongoDB.Driver;
using ProductService.Domain.Entities;
using System.Linq.Expressions;
using System.Linq;
using MongoDB.Driver.Linq;
namespace ProductService.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _dbContext;

        public ProductsRepository(ProductsContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> SaveProductAsync(string categoryid, List<ProductsDTO> productDtos)
        {
            try
            {

                await _dbContext.Products.InsertManyAsync(productDtos.Select(p => new ProductsEntity
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = ObjectId.Parse(categoryid),
                    Description = p.Description,
                    Tags = p.Tags,
                    Attributes = p.Attributes,
                    ImageUrl = p.ImageUrl,
                    IsActive = true,
                }).ToList());

                return true;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<ProductsDTO> GetProductsbyId(string id)
        {
            try
            {
                ProductsDTO productsDto = await _dbContext.Products.AsQueryable().Where(a => a.Id == ObjectId.Parse(id)).Select(p => new ProductsDTO
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId.ToString(),
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }).FirstOrDefaultAsync();

                return productsDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateProduct(string id, ProductsDTO productsDto)
        {
            try
            {
                var productsEntity = Builders<ProductsEntity>.Filter.Eq(a => a.Id, ObjectId.Parse(id));
                if (productsEntity != null)
                {
                    var updateprodEntity = Builders<ProductsEntity>.Update.Set(a => a.Name, productsDto.Name)
                          .Set(a => a.Description, productsDto.Description)
                          .Set(a => a.Price, productsDto.Price)
                          .Set(a => a.Attributes, productsDto.Attributes)
                          .Set(a => a.CategoryId, ObjectId.Parse(productsDto.CategoryId));

                    await _dbContext.Products.UpdateOneAsync(productsEntity, updateprodEntity);
                }


                return true;


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteProductbyId(string id)
        {
            try
            {
                var productsEntity = Builders<ProductsEntity>.Filter.Eq(a => a.Id, ObjectId.Parse(id));
                if (productsEntity != null)
                {

                    await _dbContext.Products.DeleteOneAsync(productsEntity);
                }
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}