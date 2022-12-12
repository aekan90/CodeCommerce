using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {



        [HttpGet]
        public List<Product> GetAllProducts()
        {
            IProductService productService = new ProductManager(new EfProductDal());
            var result = productService.GetAll();
            return result.Data;
        }
    }
}