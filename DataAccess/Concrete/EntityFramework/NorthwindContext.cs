using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : Db taboları ile Projemiz Entitylerini bağlar
    public class NorthwindContext : DbContext
    {
        // Burası projemiz hangi DB ile ilişkili beliritoyruz? 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BDSU88V;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
