using FinalProject.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Presentation.Controllers
{
    [Route("api/discharged")]
    [ApiController]
    public class DischargedPatientController : ControllerBase
    {
        private readonly IServiceManager? _serviceManager;
        public DischargedPatientController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IActionResult GetAllDischargedPatients()
        {
            var dpatients = _serviceManager.DischargedPatientService.GetAllPatients(trackChanges: false);
            return Ok(dpatients);
        }
    }
}
