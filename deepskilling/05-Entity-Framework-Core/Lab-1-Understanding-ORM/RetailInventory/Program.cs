using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

var services = new ServiceCollection();

services.AddDbContext<RetailDbContext>(options =>
    options.UseSqlServer(
        "Server=(localdb)\\MSSQLLocalDB;Database=RetailInventoryDB;Trusted_Connection=True;TrustServerCertificate=True;"));

var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<RetailDbContext>();

var products = context.Products.ToList();

Console.WriteLine("Product List");
Console.WriteLine("----------------------------");

foreach (var product in products)
{
    Console.WriteLine($"ID: {product.ProductId}");
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine($"Quantity: {product.Quantity}");
    Console.WriteLine();
}