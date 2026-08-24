using KBM.Application.DTOs;

namespace KBM.Application.Interfaces
{
    public interface IDepartmentFunctionService
    {
        Task<IReadOnlyList<DepartmentFunctionDto>> GetAllAsync();
        Task<DepartmentFunctionDto> CreateAsync(CreateDepartmentFunctionDto dto);
        Task<bool> DeleteAsync(Guid functionId, Guid departmentId);
    }
}