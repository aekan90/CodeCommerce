using Business.Abstract;
using Business.CCC;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;

        public ProductManager(IProductDal ProductDal) // EfProductDal, InMemoryDal : IProductDal
        {
            _productDal = ProductDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            if (KategoridekiUrunSayisiniSinirla(product.CategoryId).Status)
            {
                if (AyniIsimdeUrunVarsaEklenemez(product.ProductName).Status)
                {
                    _productDal.Add(product);
                    return new SuccessResult("Ürün Eklendi : " + product.ProductName);
                }
            }
            return new ErrorResult(Messages.ProductCountOfCategoryError);
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

        [ValidationAspect(typeof(ValidationAspect))]
        public IResult Update(Product product)
        {
            if (KategoridekiUrunSayisiniSinirla(product.CategoryId).Status)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProductCountOfCategoryError);
        }





        #region İŞ KURALLARI | BUSİNESS 
        private IResult KategoridekiUrunSayisiniSinirla(int CategoryId)
        {
            // Bir kategoride en fazla 10 ürün olabilir kuralımız
            // Select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == CategoryId).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }  
            return new SuccessResult();
        }

        private IResult AyniIsimdeUrunVarsaEklenemez(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        #endregion
    }
}
