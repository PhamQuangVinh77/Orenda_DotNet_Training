using DotNetTrainingProject.DbContexts;
using DotNetTrainingProject.Entities;
using DotNetTrainingProject.Repositories.IRepositories;

namespace DotNetTrainingProject.Repositories
{
    public class ProductGroupRepository : GenericRepository<ProductGroup>, IProductGroupRepository
    {
        public ProductGroupRepository(MyTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}
