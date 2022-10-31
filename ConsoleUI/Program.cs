using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System.Net.Http.Headers;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        
        foreach (var item in pm.GetAll())
        {
            Console.WriteLine(item.ProductName);
        }
    }
}