﻿using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        //List<Customer> GetAll();
        //void Add(Customer c);
        //void Update(Customer c);
        //void Delete(Customer c);
    }
}
