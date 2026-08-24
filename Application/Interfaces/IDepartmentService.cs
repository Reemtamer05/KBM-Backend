using KBM.Application.DTOs;

namespace KBM.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IReadOnlyList<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto?> GetByIdAsync(Guid id);
        Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateDepartmentDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}