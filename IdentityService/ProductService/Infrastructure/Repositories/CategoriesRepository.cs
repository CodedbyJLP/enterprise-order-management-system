using MongoDB.Bson;
using MongoDB.Driver;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ProductsContext _dbContext;
        public CategoriesRepository(ProductsContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> SaveCategoryAsync(CategoryDto categoryDto)
        {

            CategoryEntity category = new CategoryEntity()
            {
                Id = ObjectId.GenerateNewId(),
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                IsActive = categoryDto.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Categories.InsertOneAsync(category);
            return true;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(string id)
        {
            try
            {
                CategoryDto categoryDto = null;
                CategoryEntity category = await _dbContext.Categories.Find(c => c.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
                if (category != null)
                {
                    return new CategoryDto()
                    {
                        Id = category.Id.ToString(),
                        Name = category.Name,
                        Description = category.Description,
                        IsActive = category.IsActive,
                        CreatedAt = category.CreatedAt
                    };
                }

                return categoryDto;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> UpdateCategorybyId(CategoryDto categoryDto)
        {
            try
            {
                var filter = Builders<CategoryEntity>.Filter.Eq(c => c.Id, ObjectId.Parse(categoryDto.Id));
                var update = Builders<CategoryEntity>.Update.
                    Set(c => c.Name, categoryDto.Name)
                    .Set(c => c.Description, categoryDto.Description)
                    .Set(c => c.UpdatedAt, DateTime.UtcNow)
                    ;
                var result = await _dbContext.Categories.UpdateOneAsync(filter, update);
                return result != null ? true : false;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteCategoryByIdAsync(string id)
        {
            try
            {
                var isActivetrue = Builders<CategoryEntity>.Filter.And(Builders<CategoryEntity>.Filter.Eq(c => c.Id, ObjectId.Parse(id)),
                Builders<CategoryEntity>.Filter.Eq(c => c.IsActive, true));
                if (isActivetrue != null)
                {
                    var productsWithCategory = Builders<ProductsEntity>.Filter.Eq(p => p.CategoryId, ObjectId.Parse(id));
                    if (productsWithCategory != null)
                    {
                        var updateproducts = Builders<ProductsEntity>.Update.Set(p => p.IsActive, false)
                            .Set(p => p.UpdatedAt, DateTime.UtcNow);
                        await _dbContext.Products.UpdateManyAsync(productsWithCategory, updateproducts);
                    }
                    var update = Builders<CategoryEntity>.Update.Set(c => c.IsActive, false)
    .Set(c => c.UpdatedAt, DateTime.UtcNow);

                    var result = await _dbContext.Categories.UpdateOneAsync(isActivetrue, update);
                    return result != null ? true : false;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;

            }
        }
    }
}
