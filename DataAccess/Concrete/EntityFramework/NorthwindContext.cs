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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BDSU88V;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
            #region Set ConnectionString
#if (Debug)
            optionsBuilder.UseSqlServer(@"Server=.;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
#elif (Home)
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BDSU88V;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
#elif (Relase)
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
