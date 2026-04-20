using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ProductService.Infrastructure.MongoDB
{
    public static class MongoServiceExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoDbSettings>(
                config.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(settings.DefaultConnection);
            });

            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;

                return client.GetDatabase(settings.DatabaseName);
            });

            return services;
        }


    }

}

