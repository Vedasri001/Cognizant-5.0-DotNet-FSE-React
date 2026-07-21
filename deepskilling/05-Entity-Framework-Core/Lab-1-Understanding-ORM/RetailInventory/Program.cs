using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

var services = new ServiceCollection();

services.AddDbContext<RetailDbContext>(options =>
    options.UseSqlServer(
        "Server=(localdb)\\MSSQLLocalDB;Database=RetailInventoryDB;Trusted_Connection=True;TrustServerCertificate=True;"));

var serviceProvider = services.BuildServiceProvider();

Console.WriteLine("RetailInventory DbContext configured successfully.");