using IdentityService.ApplicationService.Interfaces;
using IdentityService.ApplicationService.Services;
using IdentityService.Infrastructure.DBContext;
using IdentityService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // This now works with the correct using directives


Console.WriteLine($"ContentRoot: {builder.Environment.ContentRootPath}");
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");


builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();


var app = builder.Build();
app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();


//app.MapGet("/", () => "Hello World!");

app.Run();
