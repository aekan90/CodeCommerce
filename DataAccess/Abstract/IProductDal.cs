using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //List<Product> GetAll();
        //void Add(Product p);
        //T Get(Expression<Func<T, bool>> filter);
        //void Update(Product p);
        //void Delete(Product p);

        // ürüne ait özel kodlar burada yazılacak o yüzden generic yapmayacağız.
        List<ProductDetailDto> GetProductDetail();
    }
}
