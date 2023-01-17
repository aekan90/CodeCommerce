using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // Context (bağlam) : Db taboları ile  Entityleri birbirine bağlar
    public class NorthwindContext : DbContext
    {
        // Burası projemiz hangi DB ile ilişkili belirtiyoruz?  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Set ConnectionString
#if (DEBUG)
            optionsBuilder.UseSqlServer(@"Server=.;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
#elif (HOME)
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BDSU88V;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
#elif (ODTU)
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BDSU88V;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
#elif (RELEASE)
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BDSU88V;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
#endif
            #endregion
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
