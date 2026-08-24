using AutoMapper;
using KBM.Application.DTOs;
using KBM.Application.Interfaces;
using KBM.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace KBM.Application.Services
{
    public class LessonService : ILessonService
    {
        private readonly IGenericRepository<Lesson> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<LessonService> _logger;

        public LessonService(IGenericRepository<Lesson> repository, IMapper mapper, ILogger<LessonService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<LessonDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<LessonDto>>(entities);
        }

        public async Task<LessonDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<LessonDto>(entity);
        }

        public async Task<LessonDto> CreateAsync(CreateLessonDto dto)
        {
            var entity = _mapper.Map<Lesson>(dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            _logger.LogInformation("Created Lesson {LessonId}", entity.Id);
            return _mapper.Map<LessonDto>(entity);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateLessonDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _mapper.Map(dto, entity);
            entity.ModifiedDate = DateTime.UtcNow;

            _repository.Update(entity);
            var saved = await _repository.SaveChangesAsync();

            _logger.LogInformation("Updated Lesson {LessonId}", id);
            return saved;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Remove(entity);
            var saved = await _repository.SaveChangesAsync();

            _logger.LogWarning("Deleted Lesson {LessonId}", id);
            return saved;
        }
    }
}