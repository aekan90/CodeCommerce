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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _productService.GetById(Id);

            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);

            return Ok(result.Message);
        }
    }
}