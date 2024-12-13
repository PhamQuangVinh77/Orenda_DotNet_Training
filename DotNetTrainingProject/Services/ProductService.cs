using AutoMapper;
using DotNetTrainingProject.Entities;
using DotNetTrainingProject.Repositories.IRepositories;
using DotNetTrainingProject.Services.IServices;
using DotNetTrainingProject.UnitOfWorks.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DotNetTrainingProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IProductRepository _productRepository;
        private IProductGroupRepository _productGroupRepository;
        private ILogger<ProductService> _logger;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ProductService> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.ProductRepository;
            _productGroupRepository = _unitOfWork.ProductGroupRepository;
            _logger = logger;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                return await _productRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _productRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> AddProduct(ProductDTO p)
        {
            try
            {
                p.Id = 0;
                var response = _mapper.Map<Product>(p);
                await _productRepository.Add(response);
                await _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProduct(ProductDTO p)
        {
            try
            {
                var check = await _productRepository.GetById(p.Id);
                if (check == null) return false;
                _mapper.Map<ProductDTO, Product>(p, check);
                _productRepository.Update(check);
                await _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var response = await _productRepository.GetById(id);
                if (response == null) return false;
                _productRepository.Delete(response);
                await _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> AddProductWithNewGroup(ProductDTO p, ProductGroupDTO g)
        {
            using (IDbContextTransaction transaction = _unitOfWork.DbContext.Database.BeginTransaction())
            {
                try
                {
                    // Add new group
                    g.Id = 0;
                    var groupResponse = _mapper.Map<ProductGroup>(g);
                    await _productGroupRepository.Add(groupResponse);
                    await _unitOfWork.Save();

                    // Add new product
                    var listGroup = await _productGroupRepository.GetAll();
                    p.ProductGroupId = listGroup.Last().Id;
                    p.Id = 0;
                    var productResponse = _mapper.Map<Product>(p);
                    await _productRepository.Add(productResponse);
                    await _unitOfWork.Save();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex.Message);

                }
            }
            return false;
        }
    }
}
