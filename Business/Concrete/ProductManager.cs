using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal ProductDal) // EfProductDal, InMemoryDal : IProductDal
        {
            _productDal = ProductDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult("Ürün Eklendi :" + product.ProductName);
        }

        public IDataResult<List<Product>> GetAll()
        {
            // İş Kodları
            return new DataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductGet); //  EfProductDal.GetAll() yada InMemoryProductDal.GetAll 
            // _productDal.xyz --> IProductDalda olmayan ama EfProductDalda olan bir metodu burada çağıramazsın (DIP)
            // Dependency Injection Prenciple | Bağımlılıkların tersine çevrilmesi
            // _productDal.DIPtest("DIP test"); çalışmaz çünkü IProductDal da böyle bir metot yok
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            // SELECT * FROM PRODUCTS WHERE CATEGORYID=2
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            // SELECT * FROM PRODUCTS WHERE UnitPrice>10 and UnitPrice<20 
            return _productDal.GetAll(P => P.UnitPrice > min && P.UnitPrice < max);
        }

        public List<ProductDetailDto> GetProductDetail()
        {
            return _productDal.GetProductDetail();
        }

        public List<Product> GetTest()
        {
            // İş Kodları
            return _productDal.GetAll(); //  EfProductDal.GetAll() yada InMemoryProductDal.GetAll 
            // _productDal.xyz --> IProductDalda olmayan ama EfProductDalda olan bir metodu burada çağıramazsın DIP
            // _productDal.DIPtest("DIP test"); çalışmaz çünkü IProductDal da böyle bir metot yok
        }

    }
}
