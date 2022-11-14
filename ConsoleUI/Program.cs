using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

internal class Program
{
    private static void Main(string[] args)
    {
        //ProductManager productManager = new ProductManager(new EfProductDal());

        //foreach (var item in productManager.GetByUnitPrice(10, 20)) // DIP : üstclass ref= new altclass(); ref.sadeceüstclassta ve alt classda olan metotlar gelir.(Bağımlılıkların tersine çevrilmesi)
        //{
        //    Console.WriteLine(item.ProductName);
        //}

        OrderManager orderManager = new OrderManager(new EfOrderDal());

        foreach (var item in orderManager.GetAll())
        {
            Console.WriteLine(item.OrderID + " " + item.CustomerId);
        }

    }
}