using Microsoft.AspNetCore.Mvc;
using PcMAG2.Services;

namespace PcMAG2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var response = _service.GetAllProducts();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _service.GetProductById(id);
            if (response != null)
                return Ok(response);
            return NotFound();
        }
    }
}