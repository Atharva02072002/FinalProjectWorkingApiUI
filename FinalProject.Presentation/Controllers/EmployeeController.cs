using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _svc;
        public EmployeeController(IServiceManager svc) => _svc = svc;

        [HttpGet]
        public IActionResult GetAll() =>
            Ok(_svc.EmployeeService.GetAllEmployees(false));

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) =>
            Ok(_svc.EmployeeService.GetEmployeeById(id, false));

        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDto dto)
        {
            var createdDto = _svc.EmployeeService.CreateEmployee(dto);
            return CreatedAtAction(nameof(Get), new { id = createdDto.Id }, createdDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] EmployeeDto dto)
        {
            _svc.EmployeeService.UpdateEmployee(id, dto, true);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _svc.EmployeeService.DeleteEmployee(id, false);
            return NoContent();
        }
    }
}
