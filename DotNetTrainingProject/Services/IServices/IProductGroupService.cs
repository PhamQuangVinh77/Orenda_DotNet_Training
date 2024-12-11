using DotNetTrainingProject.Entities;

namespace DotNetTrainingProject.Services.IServices
{
    public interface IProductGroupService
    {
        Task<List<ProductGroup>> GetAllProductGroups();
        Task<ProductGroup> GetProductGroupById(int id);
        Task<bool> AddProductGroup(ProductGroupDTO p);
        Task<bool> UpdateProductGroup(ProductGroupDTO p);
    }
}
