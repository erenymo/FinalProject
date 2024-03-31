using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] // Route --> insanlar istek yaparken bize nasıl ulaşsın
    [ApiController] // ATTRIBUTE (Java'daki ANNOTATION)
    // bir controller'in controller olabilmesi için onun ControllerBase'den inherit edilmesi gerekiyor
    public class ProductsController : ControllerBase
    {
        //Loosely Coupled (Soyuta bağımlılık)(gevşek bağımlılık)
        //IoC Container --> Inversion of Control --> somut referans vermek
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
