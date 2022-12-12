using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {

        _ProductManagerAddTest();
        Console.WriteLine("------------------??-----------------");
        _ProductManagerTest();
        Console.WriteLine("-----------------------------------");
        _ProductManagerGetProductTest();
        Console.WriteLine("-------------------------------------");
        _OrderManagerTest();
        Console.WriteLine("-----------------------------------");
        _CategoryManagerTest();
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

        var result = productManager.GetProductDetail();
        if (result.Status == true)
        {
            foreach (var item in productManager.GetProductDetail().Data)
            {
                Console.WriteLine(item.ProductName + " | " + item.CategoryName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }

    private static void _ProductManagerGetProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        Console.WriteLine(productManager.GetById(3).Data.ProductName);
    }

    private static void _ProductManagerAddTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        Product p = new Product();
        p.ProductName = "ayran";
        p.CategoryId = 5;
        IResult _result = productManager.Add(p);
        Console.WriteLine(_result.Message);
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



//1 2 3 4 5 6 7 8 9 0
//Q W E R T Y U I O P Ğ Ü 
//A S D F G H J K L Ş İ 
//Z X C V B N M Ö Ç  