using ProductService.ApplicationService.Interfaces;
using ProductService.ApplicationService.Services;
using ProductService.Infrastructure;
using ProductService.Infrastructure.MongoDB;
using ProductService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMongoDb(builder.Configuration);

builder.Services.AddSingleton<ProductsContext>();

builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductInvetoryService, ProductInvetoryService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IProductImagesService, ProductImagesService>();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsInvetoryRepository, ProductsInvetoryRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IProductImagesRepository, ProductImagesRepository>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
