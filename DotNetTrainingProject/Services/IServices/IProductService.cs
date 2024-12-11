using DotNetTrainingProject.Entities;

namespace DotNetTrainingProject.Services.IServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<bool> AddProduct(ProductDTO p);
        Task<bool> UpdateProduct(ProductDTO p);
        Task<bool> DeleteProduct(int id);
        Task<bool> AddProductWithNewGroup(ProductDTO p, ProductGroupDTO g);
    }
}
