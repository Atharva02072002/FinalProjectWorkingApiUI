using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/ambulances")]
    public class AmbulanceController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AmbulanceController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public IActionResult GetAllAmbulances()
        {
            var ambulances = _service.AmbulanceService.GetAllAmbulances(trackChanges: false);
            return Ok(ambulances);
        }

        [HttpGet("{id:guid}", Name = "GetAmbulanceById")]
        public IActionResult GetAmbulanceById(Guid id)
        {
            var ambulance = _service.AmbulanceService.GetAmbulanceById(id, trackChanges: false);
            return Ok(ambulance);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AmbulanceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdAmbulance = _service.AmbulanceService.CreateAmbulance(dto);
                return CreatedAtRoute("GetAmbulanceById", new { id = createdAmbulance.AmbulanceId }, createdAmbulance);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpPut("{id:guid}")]
        public IActionResult UpdateAmbulance(Guid id, [FromBody] AmbulanceDto ambulanceDto)
        {
            if (ambulanceDto == null)
                return BadRequest("Ambulance object is null");

            _service.AmbulanceService.UpdateAmbulance(id, ambulanceDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAmbulance(Guid id)
        {
            _service.AmbulanceService.DeleteAmbulance(id, trackChanges: false);
            return NoContent();
        }
    }
}
