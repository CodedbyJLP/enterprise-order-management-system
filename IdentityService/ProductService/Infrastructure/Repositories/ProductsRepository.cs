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

        public async Task<List<ProductsDTO>> SearchProducts(string keyword)
        {
            try
            {
                var regexFilter = new BsonRegularExpression(keyword, "i");
                List<ProductsDTO> lstproductsDto = new List<ProductsDTO>();
                var filter = Builders<ProductsEntity>.Filter.Or(
                    Builders<ProductsEntity>.Filter.Regex(p => p.Name, regexFilter),
                    Builders<ProductsEntity>.Filter.Regex(p => p.Description, regexFilter),
                    Builders<ProductsEntity>.Filter.AnyStringIn(p => p.Tags, new[] { new StringOrRegularExpression(regexFilter) })
                );

                var product = await _dbContext.Products.Find(filter).ToListAsync();

                if (product.Any())
                {
                    lstproductsDto = product.Select(p => new ProductsDTO
                    {
                        Id = p.Id.ToString(),
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        CategoryId = p.CategoryId.ToString(),
                        IsActive = p.IsActive,
                        CreatedAt = p.CreatedAt,
                        UpdatedAt = p.UpdatedAt,
                        IsAvailable = p.Quantity > 0 ? true : false,
                    }).ToList();

                }
                return lstproductsDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<ProductsDTO>> SearchProductsbyCategoryId(string categoryId, decimal minprice, decimal maxprice)
        {
            try
            {
                List<ProductsDTO> lstproductsDto = new List<ProductsDTO>();
                var productfilters = Builders<ProductsEntity>.Filter.And(
                    Builders<ProductsEntity>.Filter.Gte(p => p.Price, minprice),
                    Builders<ProductsEntity>.Filter.Lte(p => p.Price, maxprice),
                    Builders<ProductsEntity>.Filter.Eq(p => p.CategoryId, ObjectId.Parse(categoryId))
                );
                var products = await _dbContext.Products.Find(productfilters).ToListAsync();
                if (products.Any())
                {
                    lstproductsDto = products.Select(p => new ProductsDTO
                    {
                        Id = p.Id.ToString(),
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        CategoryId = p.CategoryId.ToString(),
                        IsActive = p.IsActive,
                        CreatedAt = p.CreatedAt,
                        UpdatedAt = p.UpdatedAt,
                        IsAvailable = p.Quantity > 0 ? true : false,
                    }).ToList();
                }

                return lstproductsDto;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public Task<List<ProductsDTO>> SortProductsbyField(string field, string order)
        {
            try
            {



            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}