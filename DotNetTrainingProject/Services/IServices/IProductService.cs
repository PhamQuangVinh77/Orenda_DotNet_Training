using DotNetTrainingProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingProject.Services.IServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById([FromForm] int id);
        Task<bool> AddProduct([FromBody] ProductDTO p);
        Task<bool> UpdateProduct([FromBody] ProductDTO p);
        Task<bool> DeleteProduct([FromForm] int id);
    }
}
