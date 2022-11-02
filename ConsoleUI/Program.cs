using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager pm = new ProductManager(new EfProductDal());

        List<Product> productList = pm.GetAll();

        foreach (var item in pm.GetAll())
        {
            Console.WriteLine(item.ProductName);
        }
    }
}