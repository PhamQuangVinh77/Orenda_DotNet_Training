using DotNetTrainingProject.Entities;
using DotNetTrainingProject.Models.Requests;
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
            var response = await _service.AddProduct(p);
            if (response)
            {
                return Ok("Add product successfully!");
            }
            return NotFound("Add product failed!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO p)
        {
            var response = await _service.UpdateProduct(p);
            if (response)
            {
                return Ok("Update product successfully!");
            }
            return NotFound("Update product failed!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromForm] int id)
        {
            var response = await _service.DeleteProduct(id);
            if (response)
            {
                return Ok("Delete product successfully!");
            }
            return NotFound("Delete product failed!");
        }

        [HttpPost("add-product-with-new-group")]
        public async Task<IActionResult> AddProductWithNewGroup([FromBody] TestTransactionRequest request)
        {
            var response = await _service.AddProductWithNewGroup(request.Product, request.ProductGroup);
            if (response)
            {
                return Ok("Add successfully!");
            }
            return NotFound("Add failed!");
        }
    }
}
