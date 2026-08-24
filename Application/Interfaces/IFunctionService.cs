using KBM.Application.DTOs;

namespace KBM.Application.Interfaces
{
    public interface IFunctionService
    {
        Task<IReadOnlyList<FunctionDto>> GetAllAsync();
        Task<FunctionDto?> GetByIdAsync(Guid id);
        Task<FunctionDto> CreateAsync(CreateFunctionDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateFunctionDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}