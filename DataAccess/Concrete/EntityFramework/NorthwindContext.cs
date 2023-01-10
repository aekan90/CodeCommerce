using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // Context (bağlam) : Db taboları ile  Entityleri birbirine bağlar
    public class NorthwindContext : DbContext
    {
        // Burası projemiz hangi DB ile ilişkili beliritoyruz? 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Set ConnectionString
#if (Nvi)
            optionsBuilder.UseSqlServer(@"Server=.;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
#elif (Home)
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BDSU88V;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
#elif (Relase)
            // relase : canlıya alırsan canlı db bilgilerin için burası
#else 
            // relase : canlıya alırsan canlı db bilgilerin için burası
#endif
            #endregion
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
