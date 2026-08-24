using KBM.Application.DTOs;

namespace KBM.Application.Interfaces
{
    public interface ILessonService
    {
        Task<IReadOnlyList<LessonDto>> GetAllAsync();
        Task<LessonDto?> GetByIdAsync(Guid id);
        Task<LessonDto> CreateAsync(CreateLessonDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateLessonDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}