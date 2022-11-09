﻿using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal ProductDal) // EfProductDal, InMemoryDal : IProductDal
        {
            _productDal = ProductDal;
        }

        public List<Product> GetAll()
        {
            // İş Kodları
            return _productDal.GetAll(); //  EfProductDal.GetAll() yada InMemoryProductDal.GetAll 


        }
    }
}
