using Asp.Versioning;
using KBM.Application.DTOs;
using KBM.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KBM.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "Admin")]
    public class DepartmentFunctionsController : ControllerBase
    {
        private readonly IDepartmentFunctionService _service;

        public DepartmentFunctionsController(IDepartmentFunctionService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<DepartmentFunctionDto>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<ActionResult<DepartmentFunctionDto>> Create(CreateDepartmentFunctionDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpDelete("{functionId:guid}/{departmentId:guid}")]
        public async Task<IActionResult> Delete(Guid functionId, Guid departmentId)
            => await _service.DeleteAsync(functionId, departmentId) ? NoContent() : NotFound();
    }
}