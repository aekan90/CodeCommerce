using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var item in productManager.GetByUnitPrice(10, 20)) // DIP : üstclass ref= new altclass(); ref.sadeceüstclassta ve alt classda olan metotlar gelir.(Bağımlılıkların tersine çevrilmesi)
        {
            Console.WriteLine(item.ProductName);
        }
    }
}