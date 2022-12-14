using TransportCompany.DAL;
using Microsoft.EntityFrameworkCore;
using TransportCompany.DAL.Repository;
using TransportCompany.DAL.Interfaces;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<TransportCompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repository
services.AddScoped<IDriverRepository, DriverRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<IStorageRepository, StorageRepository>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IOrderRepository, OrderRepository>();
services.AddScoped<ITransportationRepository, TransportationRepository>();
services.AddScoped<IDistancesRepository, DistanceRepository>();
services.AddScoped<IVehicleRepository, VehicleRepository>();

// Services
services.AddScoped<IDriverService, DriverService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IStorageService, StorageService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<ITransportationService, TransportationService>();
services.AddScoped<IVehicleService, VehicleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
