using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public List<Order> GetAll()
        {
            // İş Kodları
            return _orderDal.GetAll(); //  EfProductDal.GetAll() yada InMemoryProductDal.GetAll 
            // _productDal.xyz --> IProductDalda olmayan ama EfProductDalda olan bir metodu burada çağıramazsın DIP
            // _productDal.DIPtest("DIP test"); çalışmaz çünkü IProductDal da böyle bir metot yok
        }

        public List<Order> GetAllByEmployeeId(int id)
        {
            return _orderDal.GetAll(o => o.EmployeeId == id);
        }

        public List<Order> GetByDate(DateTime startDate, DateTime endDate)
        {
            return _orderDal.GetAll(P => P.OrderDate > startDate && P.OrderDate < endDate);
        }
    }
}
