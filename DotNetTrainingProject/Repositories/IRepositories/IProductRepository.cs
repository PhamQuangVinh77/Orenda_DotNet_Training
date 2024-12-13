using DotNetTrainingProject.DbContexts;
using DotNetTrainingProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetTrainingProject.Repositories.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
    }
}
