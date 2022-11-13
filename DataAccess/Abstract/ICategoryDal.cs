using Core.DataAccess;
using Entities.Concrete;
using System.Globalization;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        //List<Category> GetAll();
        //void Add(Category c);
        //void Update(Category c);
        //void Delete(Category c);
    }
}
