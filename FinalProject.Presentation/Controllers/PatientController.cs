using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProject.Presentation.Controllers
{
    [ApiController]

    [Route("api/patients")]

    public class PatientController : ControllerBase

    {

        private readonly IServiceManager _service;

        public PatientController(IServiceManager service) =>

            _service = service;

        [HttpGet]

        public IActionResult GetAllPatients()

        {

            var patients = _service.PatientService.GetAllPatients(trackChanges: false);

            return Ok(patients);

        }

        [HttpGet("{id:guid}", Name = "GetPatientById")]

        public IActionResult GetPatientById(Guid id)

        {

            var patient = _service.PatientService.GetPatientById(id, trackChanges: false);

            if (patient == null) return NotFound();

            return Ok(patient);

        }

        [HttpPost]

        public IActionResult CreatePatient([FromBody] PatientDto patientDto)

        {

            if (patientDto == null)

                return BadRequest("Patient object is null");

            var createdPatient = _service.PatientService.CreatePatient(patientDto);

            return CreatedAtRoute("GetPatientById", new { id = createdPatient.PatientId }, createdPatient);

        }

        [HttpPut("{id:guid}")]

        public IActionResult UpdatePatient(Guid id, [FromBody] PatientDto patientDto)

        {

            if (patientDto == null)

                return BadRequest("Patient object is null");

            _service.PatientService.UpdatePatient(id, patientDto, trackChanges: true);

            return NoContent();

        }

        [HttpDelete("{id:guid}")]

        public IActionResult DeletePatient(Guid id)

        {

            _service.PatientService.DeletePatient(id, trackChanges: false);

            return NoContent();

        }

    }
}
