using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
using Core.CrossCuttingConcerns.Validations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal ProductDal) // EfProductDal, InMemoryDal : IProductDal
        {
            _productDal = ProductDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            // loglama kodları çalışacak
            // ValidationTool.Validate(new ProductValidator(), product);
            // business codes
            _productDal.Add(product);
            return new SuccessResult("Ürün Eklendi : " + product.ProductName);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult("Ürün Silindi : " + product.ProductName);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
            }

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            // SELECT * FROM PRODUCTS WHERE CATEGORYID=2
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            // SELECT * FROM PRODUCTS WHERE UnitPrice>10 and UnitPrice<20 
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(P => P.UnitPrice > min && P.UnitPrice < max), Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            if (DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime); // Data null gitti???
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetTest()
        {
            // İş Kodları
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed); //  EfProductDal.GetAll() yada InMemoryProductDal.GetAll 
            // _productDal.xyz --> IProductDalda olmayan ama EfProductDalda olan bir metodu burada çağıramazsın DIP
            // _productDal.DIPtest("DIP test"); çalışmaz çünkü IProductDal da böyle bir metot yok
        }



    }
}
