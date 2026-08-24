using AutoMapper;
using KBM.Application.DTOs;
using KBM.Application.Interfaces;
using KBM.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace KBM.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(IGenericRepository<Department> repository, IMapper mapper, ILogger<DepartmentService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<DepartmentDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<DepartmentDto>>(entities);
        }

        public async Task<DepartmentDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<DepartmentDto>(entity);
        }

        public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto)
        {
            var entity = _mapper.Map<Department>(dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            _logger.LogInformation("Created Department {DepartmentId}", entity.Id);
            return _mapper.Map<DepartmentDto>(entity);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateDepartmentDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            entity.Name = dto.Name;
            entity.ModifiedDate = DateTime.UtcNow;

            _repository.Update(entity);
            var saved = await _repository.SaveChangesAsync();

            _logger.LogInformation("Updated Department {DepartmentId}", id);
            return saved;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Remove(entity);
            var saved = await _repository.SaveChangesAsync();

            _logger.LogWarning("Deleted Department {DepartmentId}", id);
            return saved;
        }
    }
}