using AutoMapper;
using KBM.Application.DTOs;
using KBM.Application.Interfaces;
using KBM.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace KBM.Application.Services
{
    public class IndustryService : IIndustryService
    {
        private readonly IGenericRepository<Industry> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<IndustryService> _logger;

        public IndustryService(IGenericRepository<Industry> repository, IMapper mapper, ILogger<IndustryService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<IndustryDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<IndustryDto>>(entities);
        }

        public async Task<IndustryDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<IndustryDto>(entity);
        }

        public async Task<IndustryDto> CreateAsync(CreateIndustryDto dto)
        {
            var entity = _mapper.Map<Industry>(dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            _logger.LogInformation("Created Industry {IndustryId}", entity.Id);
            return _mapper.Map<IndustryDto>(entity);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateIndustryDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            entity.Name = dto.Name;
            entity.ModifiedDate = DateTime.UtcNow;

            _repository.Update(entity);
            var saved = await _repository.SaveChangesAsync();

            _logger.LogInformation("Updated Industry {IndustryId}", id);
            return saved;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Remove(entity);
            var saved = await _repository.SaveChangesAsync();

            _logger.LogWarning("Deleted Industry {IndustryId}", id);
            return saved;
        }
    }
}