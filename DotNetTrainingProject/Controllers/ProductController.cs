using DotNetTrainingProject.Entities;
using DotNetTrainingProject.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingProject.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Product>> GetAllProducts()
        {
            var listResponse = await _service.GetAllProducts();
            return listResponse;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProductById([FromForm] int id)
        {
            var response = await _service.GetProductById(id);
            return response;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO p)
        {
            await _service.AddProduct(p);
            return Ok("Thêm thành công!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO p)
        {
            await _service.UpdateProduct(p);
            return Ok("Update thành công!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromForm] int id)
        {
            await _service.DeleteProduct(id);
            return Ok("Xoá thành công!");
        }
    }
}
