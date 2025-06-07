using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IServiceManager _svc;
        public DepartmentController(IServiceManager svc) => _svc = svc;

        [HttpGet] public IActionResult GetAll() => Ok(_svc.DepartmentService.GetAllDepartments(false));
        [HttpGet("{id}")] public IActionResult Get(int id) => Ok(_svc.DepartmentService.GetDepartmentById(id, false));
        [HttpPost]
        public IActionResult Post([FromBody] DepartmentDto dto)
        {
            _svc.DepartmentService.CreateDepartment(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.DepartmentId }, dto);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DepartmentDto dto)
        {
            _svc.DepartmentService.UpdateDepartment(id, dto, true);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _svc.DepartmentService.DeleteDepartment(id, false);
            return NoContent();
        }
    }
}
