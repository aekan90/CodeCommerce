using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

internal class Program
{
    private static void Main(string[] args)
    {
        _ProductManagerTest();
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

        foreach (var item in productManager.GetProductDetail()) // DIP : üstclass ref= new altclass(); ref.sadeceüstclassta ve alt classda olan metotlar gelir.(Bağımlılıkların tersine çevrilmesi)
        {
            Console.WriteLine(item.ProductId + " | " + item.ProductName + " | " + item.CategoryName);
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

    //1 2 3 4 5 6 7 8 9 0
    //Q W E R T Y U I O P Ğ Ü 
    //A S D F G H J K L Ş İ 
    //Z X C V B N M Ö Ç  
}