using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Contract
{
    public interface IDischargedPatientService
    {
        IEnumerable<DischargedPatient> GetAllPatients(bool trackChanges);
    }
}
