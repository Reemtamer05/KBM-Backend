using AutoMapper;
using KBM.Application.DTOs;
using KBM.Application.Interfaces;
using KBM.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace KBM.Application.Services
{
    public class FunctionService : IFunctionService
    {
        private readonly IGenericRepository<Function> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<FunctionService> _logger;

        public FunctionService(IGenericRepository<Function> repository, IMapper mapper, ILogger<FunctionService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<FunctionDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<FunctionDto>>(entities);
        }

        public async Task<FunctionDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<FunctionDto>(entity);
        }

        public async Task<FunctionDto> CreateAsync(CreateFunctionDto dto)
        {
            var entity = _mapper.Map<Function>(dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            entity.LastModifiedDate = DateTime.UtcNow;

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            _logger.LogInformation("Created Function {FunctionId}", entity.Id);
            return _mapper.Map<FunctionDto>(entity);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateFunctionDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            entity.Name = dto.Name;
            entity.LastModifiedDate = DateTime.UtcNow;

            _repository.Update(entity);
            var saved = await _repository.SaveChangesAsync();

            _logger.LogInformation("Updated Function {FunctionId}", id);
            return saved;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Remove(entity);
            var saved = await _repository.SaveChangesAsync();

            _logger.LogWarning("Deleted Function {FunctionId}", id);
            return saved;
        }
    }
}