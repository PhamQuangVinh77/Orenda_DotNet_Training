using AutoMapper;
using DotNetTrainingProject.Entities;
using DotNetTrainingProject.Repositories;
using DotNetTrainingProject.Repositories.IRepositories;
using DotNetTrainingProject.Services.IServices;
using DotNetTrainingProject.UnitOfWorks.Interfaces;

namespace DotNetTrainingProject.Services
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IProductGroupRepository _pgRepository;
        private ILogger<ProductGroupService> _logger;

        public ProductGroupService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ProductGroupService> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _pgRepository = _unitOfWork.ProductGroupRepository;
            _logger = logger;
        }

        public async Task<List<ProductGroup>> GetAllProductGroups()
        {
            try
            {
                return await _pgRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<ProductGroup> GetProductGroupById(int id)
        {
            try
            {
                return await _pgRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> AddProductGroup(ProductGroupDTO p)
        {
            try
            {
                p.Id = 0;
                var response = _mapper.Map<ProductGroup>(p);
                await _pgRepository.Add(response);
                await _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProductGroup(ProductGroupDTO p)
        {
            try
            {
                var check = await _pgRepository.GetById(p.Id);
                if (check == null) return false;
                var response = _mapper.Map<ProductGroup>(p);
                _pgRepository.Update(response);
                await _unitOfWork.Save();
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
