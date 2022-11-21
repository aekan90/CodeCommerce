using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

internal class Program
{
    private static void Main(string[] args)
    {
        //_ProductManagerTest();
        Console.WriteLine("-----------------------------------");
        //_OrderManagerTest();
        Console.WriteLine("-----------------------------------");
        //_CategoryManagerTest();
    }

    private static void _OrderManagerTest()
    {
        OrderManager orderManager = new OrderManager(new EfOrderDal());

        foreach (var item in orderManager.GetAll())
        {
            Console.WriteLine(item.OrderID + " " + item.CustomerId);
        }

    }

    private static void _ProductManagerTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var item in productManager.GetByUnitPrice(10, 20)) // DIP : üstclass ref= new altclass(); ref.sadeceüstclassta ve alt classda olan metotlar gelir.(Bağımlılıkların tersine çevrilmesi)
        {
            Console.WriteLine(item.ProductName);
        }
    }

    private static void _CategoryManagerTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        foreach (var item in categoryManager.GetAll())
        {
            Console.WriteLine(item.CategoryName);
        }
    }
}