
using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    {   // validasyonları buraya eklemeyiz
        // solide aykırı olur
        // burası IEntity imzalıdır yani bir DB karşılığı vardır
        // eklediğin validasyon attribütü db de yokki
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
