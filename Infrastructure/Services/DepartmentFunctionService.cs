using AutoMapper;
using KBM.Application.DTOs;
using KBM.Application.Interfaces;
using KBM.Domain.Entities;
using KBM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KBM.Infrastructure.Services
{

    public class DepartmentFunctionService : IDepartmentFunctionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentFunctionService> _logger;

        public DepartmentFunctionService(AppDbContext context, IMapper mapper, ILogger<DepartmentFunctionService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<DepartmentFunctionDto>> GetAllAsync()
        {
            var entities = await _context.DepartmentFunctions
                .Include(df => df.Function)
                .Include(df => df.Department)
                .ToListAsync();

            return _mapper.Map<IReadOnlyList<DepartmentFunctionDto>>(entities);
        }

        public async Task<DepartmentFunctionDto> CreateAsync(CreateDepartmentFunctionDto dto)
        {
            var entity = new DepartmentFunction
            {
                FunctionId = dto.FunctionId,
                DepartmentId = dto.DepartmentId
            };

            _context.DepartmentFunctions.Add(entity);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Linked Function {FunctionId} to Department {DepartmentId}", dto.FunctionId, dto.DepartmentId);

            await _context.Entry(entity).Reference(e => e.Function).LoadAsync();
            await _context.Entry(entity).Reference(e => e.Department).LoadAsync();
            return _mapper.Map<DepartmentFunctionDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid functionId, Guid departmentId)
        {
            var entity = await _context.DepartmentFunctions
                .FirstOrDefaultAsync(df => df.FunctionId == functionId && df.DepartmentId == departmentId);

            if (entity is null) return false;

            _context.DepartmentFunctions.Remove(entity);
            var saved = await _context.SaveChangesAsync() > 0;

            _logger.LogWarning("Unlinked Function {FunctionId} from Department {DepartmentId}", functionId, departmentId);
            return saved;
        }
    }
}
