using AutoMapper;
using DotNetTrainingProject.DbContexts;
using DotNetTrainingProject.Entities;
using DotNetTrainingProject.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetTrainingProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private MyTestDbContext _dbContext;
        private ILogger<ProductService> _logger;

        public ProductService(IMapper mapper, MyTestDbContext dbContext, ILogger<ProductService> logger)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                return await _dbContext.Products.ToListAsync();
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Product> GetProductById([FromForm] int id)
        {
            try
            {
                return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> AddProduct([FromBody] ProductDTO p)
        {
            try
            {
                p.Id = 0;
                var response = _mapper.Map<Product>(p);
                await _dbContext.Products.AddAsync(response);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProduct([FromBody] ProductDTO p)
        {
            try
            {
                var response = _mapper.Map<Product>(p);
                _dbContext.Products.Update(response);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteProduct([FromForm] int id)
        {
            try
            {
                var response = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
                if(response == null) return false;
                _dbContext.Products.Remove(response);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
