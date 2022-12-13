using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
           _productService = productService;
        }

        //IProductService productService = new ProductManager(new EfProductDal());

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}