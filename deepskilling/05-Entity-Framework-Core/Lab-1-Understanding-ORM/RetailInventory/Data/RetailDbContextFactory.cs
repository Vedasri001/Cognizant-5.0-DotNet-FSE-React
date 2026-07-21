using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RetailInventory.Data
{
    public class RetailDbContextFactory : IDesignTimeDbContextFactory<RetailDbContext>
    {
        public RetailDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RetailDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=RetailInventoryDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new RetailDbContext(optionsBuilder.Options);
        }
    }
}