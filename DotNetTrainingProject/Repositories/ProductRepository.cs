using DotNetTrainingProject.DbContexts;
using DotNetTrainingProject.Entities;
using DotNetTrainingProject.Repositories.IRepositories;

namespace DotNetTrainingProject.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MyTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}
