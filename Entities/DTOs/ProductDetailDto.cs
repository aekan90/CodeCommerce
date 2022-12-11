using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {   // join operasyonu
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
