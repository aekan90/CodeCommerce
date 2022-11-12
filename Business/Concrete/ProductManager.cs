using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal ProductDal) // EfProductDal, InMemoryDal : IProductDal
        {
            _productDal = ProductDal;
        }

        public List<Product> GetAll()
        {
            // İş Kodları
            return _productDal.GetAll(); //  EfProductDal.GetAll() yada InMemoryProductDal.GetAll 
            // _productDal.xyz --> IProductDalda olmayan ama EfProductDalda olan bir metodu burada çağıramazsın DIP
            // _productDal.DIPtest("DIP test"); çalışmaz çünkü IProductDal da böyle bir metot yok
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            // SELECT * FROM PRODUCTS WHERE CATEGORYID=2
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            // SELECT * FROM PRODUCTS WHERE UnitPrice>10 and UnitPrice<20 
            return _productDal.GetAll(P => P.UnitPrice > min && P.UnitPrice < max);
        }
    }
}
