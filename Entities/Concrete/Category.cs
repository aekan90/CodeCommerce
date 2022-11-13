using Core.Entities;

namespace Entities.Concrete
{
    // Çıplak class kalmasın --> Bütün classları işaretler yoksa ilerde sorun yaşarsın
    public class Category : IEntity // (IEntity ile işaretlenmişse bunun DB de karşılığı vardır)
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
