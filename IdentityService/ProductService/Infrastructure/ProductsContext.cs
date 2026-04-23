using MongoDB.Driver;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.MongoDB;

namespace ProductService.Infrastructure
{
    public class ProductsContext
    {
        private readonly IMongoDatabase _database;

        public ProductsContext(IConfiguration config, IMongoClient client)
        {
            var settings = config.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<ProductsEntity> Products =>
            _database.GetCollection<ProductsEntity>("Products");
        public IMongoCollection<ProductImages> ProductImages =>
            _database.GetCollection<ProductImages>("ProductImages");

        public IMongoCollection<ProductInventory> ProductInventory =>
            _database.GetCollection<ProductInventory>("ProductInventory");

        public IMongoCollection<CategoryEntity> Categories =>
          _database.GetCollection<CategoryEntity>("Category");

        //public IMongoCollection<ProductAttributes> Attributes =>
        // _database.GetCollection<ProductAttributes>("Attributes");
    }
}
