using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IEntityRepository<Product>
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>() {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }
        // LINQ (LANGUAGE INTEGRATED QUERY)
        // LINQ : sana doğrudan heap adresindeki nesneyi getirir DB den getirir gibi
        //        YANİ, doğrudan bellek üzerinden nesneye erişimin olur.

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            List<Product> pList = new List<Product>();
            pList = _products.Where(P => P.CategoryId == categoryId).ToList();
            return pList;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.FirstOrDefault(P => P.ProductId == product.ProductId);
            //_products.Update(productToUpdate); böyle bir kullanım yok
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
