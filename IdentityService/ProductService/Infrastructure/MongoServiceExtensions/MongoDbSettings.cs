namespace ProductService.Infrastructure.MongoDB
{
    public class MongoDbSettings
    {

        public string DefaultConnection { get; set; } 
        public string DatabaseName { get; set; } 
        public string ProductsCollection { get; set; } 

    }
}
