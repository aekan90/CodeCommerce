using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //List<Product> GetAll();
        //void Add(Product p);
        //void Update(Product p);
        //void Delete(Product p);
    }
}
