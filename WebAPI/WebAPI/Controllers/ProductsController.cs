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
        //Loosely Coupled (Soyuta bağımlılık)
        //IoC Container --> Inversion of Control --> somut referans vermek
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
