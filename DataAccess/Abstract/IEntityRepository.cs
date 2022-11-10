using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    // generic constraint
    // class : referans tip olabilir Değer Tipleri engeller (Değer tip :int, short, long | Referans Tip : string, object)
    //         Değer Tipleri:Verilerini doğrudan kendi üzerinde saklarlar. | Referans Tipleri: Verilerinin adreslerini(referanslarını) saklarlar.
    // IEntity : IEntity olabilir yada IEntity implemente eden nesne olabilir
    // new : soyut sınıf(IEntity) de gelmesin 

    public interface IEntityRepository<T> where T : class ,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
