using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    // Çıplak class kalmasın --> Bütün classları işaretler yoksa ilerde sorun yaşarsın
    public class Category : IEntity // (IEntity ile işaretlenmişse bunun DB de karşılığı vardır)
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
