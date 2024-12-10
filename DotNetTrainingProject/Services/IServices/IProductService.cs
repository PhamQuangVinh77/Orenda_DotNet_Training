using DotNetTrainingProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingProject.Services.IServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById([FromForm] int id);
        Task AddProduct([FromBody] ProductDTO p);
        Task UpdateProduct([FromBody] ProductDTO p);
        Task DeleteProduct([FromForm] int id);
    }
}
