using KBM.Application.DTOs;

namespace KBM.Application.Interfaces
{
    public interface IIndustryService
    {
        Task<IReadOnlyList<IndustryDto>> GetAllAsync();
        Task<IndustryDto?> GetByIdAsync(Guid id);
        Task<IndustryDto> CreateAsync(CreateIndustryDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateIndustryDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}